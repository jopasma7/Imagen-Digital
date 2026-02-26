using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Polygon : MonoBehaviour
{
    public float radius = 3f;
    public int numberOfSides = 5;
    public float rotationSpeed = 50f;

    private LineRenderer lineRenderer;
    private int previousNumberOfSides;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        previousNumberOfSides = numberOfSides;
        DrawPolygon();
    }

    void Update()
    {
        // Rotación
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Si cambia el número de lados, redibujar
        if (numberOfSides != previousNumberOfSides)
        {
            previousNumberOfSides = numberOfSides;
            DrawPolygon();
        }
    }

    void DrawPolygon()
    {
        if (numberOfSides < 3) numberOfSides = 3;

        lineRenderer.positionCount = numberOfSides + 1;
        lineRenderer.useWorldSpace = false;

        float angleStep = 2 * Mathf.PI / numberOfSides;

        for (int i = 0; i <= numberOfSides; i++)
        {
            float angle = i * angleStep;

            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}