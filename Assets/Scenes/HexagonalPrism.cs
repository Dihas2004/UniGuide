using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexagonalPrism : MonoBehaviour
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
        MeshFilter prismMeshFilter = GetComponent<MeshFilter>();
        Mesh prismMesh = new Mesh();

        Vector3[] prismVertices = new Vector3[sides * 2];
        int[] prismTriangles = new int[sides * 6];

        for (int i = 0; i < sides; i++)
        {
            float angle = 2 * Mathf.PI / sides * i;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            prismVertices[i] = new Vector3(x, 0f, z);
            prismVertices[i + sides] = new Vector3(x, height, z);

            int nextIndex = (i + 1) % sides;

            prismTriangles[i * 6] = i;
            prismTriangles[i * 6 + 1] = (i + 1) % sides;
            prismTriangles[i * 6 + 2] = i + sides;
            prismTriangles[i * 6 + 3] = (i + 1) % sides;
            prismTriangles[i * 6 + 4] = (i + 1) % sides + sides;
            prismTriangles[i * 6 + 5] = i + sides;
        }

        prismMesh.vertices = prismVertices;
        prismMesh.triangles = prismTriangles;

        prismMeshFilter.mesh = prismMesh;
    }
}
