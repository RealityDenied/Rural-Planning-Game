using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TerrainKnifeTool : MonoBehaviour
{
    public Camera mainCamera; // Camera to cast rays from
    public Terrain terrain;   // The terrain object to cut
    public Material cutMaterial; // Material to assign to the cut area

    private List<Vector3> cutPoints = new List<Vector3>(); // List of points clicked by the user

    private Mouse mouse;

    void Start()
    {
        // Ensure the mainCamera is assigned in the Inspector or set a default if not
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Fallback to the main camera if not assigned
        }

        // Initialize Input System's Mouse device and check if available
        mouse = Mouse.current;
        if (mouse == null)
        {
            Debug.LogError("Mouse input not detected.");
        }
    }

    void Update()
    {
        if (mouse != null && mouse.leftButton.isPressed) // Check for mouse input
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(mouse.position.ReadValue());

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit collider is the terrain's collider
                if (hit.collider == terrain.GetComponent<Collider>())
                {
                    Vector3 terrainHitPoint = hit.point;
                    terrainHitPoint.y += 2f;  // Raise the point 2 units in the Y-axis
                    cutPoints.Add(terrainHitPoint); // Add point to the cut list
                    Debug.Log("Point Added: " + terrainHitPoint);
                }
            }
        }

        // When the user clicks 3 times or more, create a mesh
        if (cutPoints.Count >= 3 && Keyboard.current.enterKey.isPressed)
        {
            CreateCutMesh();
        }
    }

    void CreateCutMesh()
    {
        // Create a new GameObject as a child of the terrain
        GameObject cutMeshObject = new GameObject("CutMesh");
        cutMeshObject.transform.SetParent(terrain.transform);

        // Create a new Mesh and assign it to a MeshFilter
        MeshFilter meshFilter = cutMeshObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = cutMeshObject.AddComponent<MeshRenderer>();

        // Assign the material
        meshRenderer.material = cutMaterial;

        // Create the mesh
        Mesh cutMesh = new Mesh();
        Vector3[] vertices = cutPoints.ToArray();
        
        // Create the triangles to form a loop (using the points)
        int[] triangles = new int[(cutPoints.Count - 2) * 3];
        for (int i = 1; i < cutPoints.Count - 1; i++)
        {
            triangles[(i - 1) * 3] = 0;
            triangles[(i - 1) * 3 + 1] = i;
            triangles[(i - 1) * 3 + 2] = i + 1;
        }

        // Add the first and last triangle to close the loop
        triangles[triangles.Length - 3] = 0;
        triangles[triangles.Length - 2] = cutPoints.Count - 1;
        triangles[triangles.Length - 1] = 1;

        // Assign vertices and triangles to the mesh
        cutMesh.vertices = vertices;
        cutMesh.triangles = triangles;
        cutMesh.RecalculateNormals();

        // Set the mesh to the MeshFilter
        meshFilter.mesh = cutMesh;

        // Reset the points for the next cut
        cutPoints.Clear();
    }
}
