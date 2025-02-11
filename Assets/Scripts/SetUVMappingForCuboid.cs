using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SetUVMappingForCuboid : MonoBehaviour
{
    [Tooltip("The material to be applied to the cuboid. ")]
    public Material material;

    void Start()
    {
        ApplyUVMapping();
    }

    void ApplyUVMapping()
    {
        // Get the mesh from the MeshFilter
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        Debug.Log("Vertices count: " + mesh.vertices.Length);

        if (mesh == null || mesh.vertices.Length != 24)
        {
            Debug.LogError("This script requires a cuboid mesh with exactly 24 vertices.");
            return;
        }

        // Define UVs for each of the 24 vertices
        Vector2[] uvs = new Vector2[mesh.vertices.Length];

        // Assign unique UVs for all 6 faces
        // Face 1 (Front)
        uvs[0] = new Vector2(1, 0);
        uvs[1] = new Vector2(0, 0);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(0, 1);

        // Face 2 (Back)
        uvs[4] = new Vector2(0, 1);
        uvs[5] = new Vector2(1, 1);
        uvs[6] = new Vector2(0, 0);
        uvs[7] = new Vector2(1, 0);

        // Face 3 (Left)
        uvs[8] = new Vector2(0, 0);
        uvs[9] = new Vector2(1, 0);
        uvs[10] = new Vector2(0, 1);
        uvs[11] = new Vector2(1, 1);

        // Face 4 (Right)
        uvs[12] = new Vector2(1, 0);
        uvs[13] = new Vector2(1, 1);
        uvs[14] = new Vector2(0, 1);
        uvs[15] = new Vector2(0, 0);

        // Face 5 (Top)
        uvs[16] = new Vector2(0, 0);
        uvs[17] = new Vector2(0, 1);
        uvs[18] = new Vector2(1, 1);
        uvs[19] = new Vector2(1, 0);

        // Face 6 (Bottom)
        uvs[20] = new Vector2(1, 0);
        uvs[21] = new Vector2(1, 1);
        uvs[22] = new Vector2(0, 1);
        uvs[23] = new Vector2(0, 0);

        // Assign the UVs to the mesh
        //uv mapping done in the mesh
        mesh.uv = uvs;
        Debug.Log("Debugging Vertex Positions and UV Coordinates:");
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 worldPosition = transform.TransformPoint(mesh.vertices[i]); // Transform to world position for better visualization
            Debug.Log($"Vertex {i}: Position {worldPosition}, UV {uvs[i]}");
        }


        // Apply the material
        if (material != null)
        {
            GetComponent<MeshRenderer>().material = material;
        }
        else
        {
            Debug.LogWarning("No material assigned. Please assign a material in the inspector.");
        }
    }
}
