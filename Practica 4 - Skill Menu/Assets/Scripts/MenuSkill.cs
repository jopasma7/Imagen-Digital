using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MenuSkill : MonoBehaviour
{
    public float attack = 50;
    public float speed = 50;
    public float health = 50;
    public float defence = 50;
    public float mana = 50;
    public float strength = 50;

    public float maxRadius = 3f;

    Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
    }

    void OnValidate() 
    {
        if (mesh != null) GenerateMesh();
    }

    void GenerateMesh()
    {
        Vector3[] vertices = new Vector3[7];
        int[] triangles = new int[18];

        float[] skills = { attack, speed, health, defence, mana, strength };

        vertices[0] = Vector3.zero;

        float angleStep = 2 * Mathf.PI / 6;

        for (int i = 0; i < 6; i++)
        {
            float value = skills[i] / 100f;
            float radius = value * maxRadius;

            float angle = i * angleStep;

            vertices[i + 1] = new Vector3(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius,
                0
            );
        }

        // Cambia el orden de los índices 1 y 2 en el triángulo
        for (int i = 0; i < 6; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = (i + 2 > 6) ? 1 : i + 2; // Invertido
            triangles[i * 3 + 2] = i + 1;                  // Invertido
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}