using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class scissor : MonoBehaviour
{
    [Header("Settings")]
    public Material greenMaterial; // Material for the closed-loop area
    public float snapThreshold = 0.3f; // Distance to snap to the starting point
    public float lineWidth = 0.05f; // Width of the drawn cutting line

    private Plane cuttingPlane; // Plane for drawing and cutting
    private List<Vector3> points = new List<Vector3>(); // List of drawn points
    private LineRenderer lineRenderer; // For visualizing the cutting line
    private Camera mainCamera; // Reference to the main camera
    private bool isClicking = false; // Tracks whether the user is clicking

    void Start()
    {
        // Initialize the cutting plane (y = 0, horizontal plane)
        cuttingPlane = new Plane(Vector3.up, Vector3.zero);

        // Set up the LineRenderer for visual feedback
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        // Reference the main camera
        mainCamera = Camera.main;
    }

    // Called by the new Input System when the left mouse button is pressed
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started) // Detect mouse press
        {
            isClicking = true;
        }
        else if (context.canceled) // Detect release
        {
            isClicking = false;
        }
    }

    void Update()
    {
        if (isClicking)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        // Cast a ray from the mouse position to the cutting plane
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (cuttingPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // Snap to the starting point if close enough
            if (points.Count > 1 && Vector3.Distance(hitPoint, points[0]) < snapThreshold)
            {
                CloseLoop();
            }
            else
            {
                AddPoint(hitPoint);
            }
        }
    }

    void AddPoint(Vector3 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }

    void CloseLoop()
    {
        // Close the loop visually by connecting the last point to the first
        lineRenderer.positionCount = points.Count + 1;
        lineRenderer.SetPosition(points.Count, points[0]);

        // Cut the mesh and assign the green material
        CutMesh();

        // Clear the points for the next loop
        points.Clear();
        lineRenderer.positionCount = 0;
    }

    void CutMesh()
    {
        // Find the mesh filter on the object (or handle dynamically as needed)
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        // Create a new mesh from the closed loop
        GameObject closedArea = new GameObject("Closed Area");
        closedArea.transform.position = Vector3.zero;
        closedArea.AddComponent<MeshFilter>().mesh = CreateMeshFromPoints(points);
        closedArea.AddComponent<MeshRenderer>().material = greenMaterial;
    }

    Mesh CreateMeshFromPoints(List<Vector3> points)
    {
        // Generate a simple flat mesh based on the closed loop of points
        Mesh mesh = new Mesh();
        Vector3[] vertices = points.ToArray();
        int[] triangles = new int[(points.Count - 2) * 3];

        for (int i = 0; i < points.Count - 2; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;
    }
}
