using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TriangleMesh : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        // Define the vertices of the triangle
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 1, 0), // Top vertex
            new Vector3(-1, -1, 0), // Bottom left vertex
            new Vector3(1, -1, 0) // Bottom right vertex
        };

        // Define the triangles (each set of three integers represents one triangle)
        int[] triangles = new int[]
        {
            0, 1, 2 // Triangle
        };

        // Assign the vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalculate normals for proper lighting
        mesh.RecalculateNormals();
    }
}
