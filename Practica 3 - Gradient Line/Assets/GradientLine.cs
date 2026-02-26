using UnityEngine;

public class GradientLine : MonoBehaviour
{
    public GameObject linePrefab;

    public Color startColor = Color.red;
    public Color endColor = Color.blue;

    public float lineWidth = 0.05f;
    public int numberOfLines = 100;
    public Transform linesGroup;

    void Start()
    {
        if (linesGroup == null)
        {
            GameObject group = new GameObject("LinesGroup");
            linesGroup = group.transform;
        }

        DrawGradient();
    }

    void DrawGradient()
    {
        // Se calculan los bordes visibles de la cámara y se 
        // ajustan para que las líneas no se corten
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight   = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float yStart = bottomLeft.y + lineWidth / 2f;   
        float yEnd   = topRight.y   - lineWidth / 2f;

        float width = topRight.x - bottomLeft.x;

        for (int i = 0; i < numberOfLines; i++)
        {
            float t = (float)i / (numberOfLines - 1);
            Color currentColor = Color.Lerp(startColor, endColor, t);

            float yPos = Mathf.Lerp(yStart, yEnd, t);

            GameObject line = Instantiate(linePrefab, linesGroup);
            LineRenderer lr = line.GetComponent<LineRenderer>();

            lr.positionCount = 2;
            lr.startWidth = lineWidth;
            lr.endWidth = lineWidth;

            lr.SetPosition(0, new Vector3(bottomLeft.x, yPos, 0));
            lr.SetPosition(1, new Vector3(topRight.x, yPos, 0));

            lr.startColor = currentColor;
            lr.endColor = currentColor;
        }
    }
}