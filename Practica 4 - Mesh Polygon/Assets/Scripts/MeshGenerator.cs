using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    public Vector3 center = Vector3.zero;
    public float radius = 2f;
    public int sides = 5;
    public Material material;

    private int lastSides;

    void Start()
    {
        GenerateMesh();
        lastSides = sides;
    }

    void Update()
    {
        if (sides != lastSides)
        {
            GenerateMesh();
            lastSides = sides;
        }

        // Rotación
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[sides + 1];
        int[] triangles = new int[sides * 3];

        vertices[0] = center;

        float angle = 0f;
        float step = 2 * Mathf.PI / sides;

        for (int i = 1; i <= sides; i++)
        {
            vertices[i] = new Vector3(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius,
                0
            );

            angle += step;
        }

        for (int i = 0; i < sides; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2 > sides) ? 1 : i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        GetComponent<MeshRenderer>().material = material;
    }
}