
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class abc : MonoBehaviour
{
    public float radius = 1f;
    public float height = 1f;
    public int sides = 6;

    void Start()
    {
        CreateHexagonalPrism();
    }

    void CreateHexagonalPrism()
    {
        // Rename the GameObject to "hexagon"
        gameObject.name = "hexagon";

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        // Create hexagon vertices
        Vector3[] hexagonVertices = new Vector3[sides];
        for (int i = 0; i < sides; i++)
        {
            float angle = 2 * Mathf.PI / sides * i;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            hexagonVertices[i] = new Vector3(x, 0f, z);
        }

        // Extrude hexagon to create hexagonal prism
        Vector3[] vertices = new Vector3[sides * 2];
        int[] triangles = new int[sides * 6];

        for (int i = 0; i < sides; i++)
        {
            vertices[i] = hexagonVertices[i];
            vertices[i + sides] = hexagonVertices[i] + Vector3.up * height;

            int nextIndex = (i + 1) % sides;

            triangles[i * 6] = i;
            triangles[i * 6 + 1] = (i + 1) % sides;
            triangles[i * 6 + 2] = i + sides;
            triangles[i * 6 + 3] = (i + 1) % sides;
            triangles[i * 6 + 4] = (i + 1) % sides + sides;
            triangles[i * 6 + 5] = i + sides;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;
    }
}
