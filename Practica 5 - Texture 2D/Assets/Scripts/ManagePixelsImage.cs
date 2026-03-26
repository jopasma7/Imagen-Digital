using UnityEngine;

public class ManagePixelsImage : MonoBehaviour
{
    public Texture2D image;          // Imagen a modificar
    public Color targetColor;        // Color que queremos reemplazar
    public Color paintColor;         // Color nuevo
    [Range(0f, 1f)]
    public float tolerance = 0.5f;   // Tolerancia para detectar colores similares

    private Texture2D originalImage; // Para restaurar la imagen al detener la escena

    private void Awake()
    {
        // Guardamos una copia de la textura original
        originalImage = Instantiate(image);
    }

    private void Start()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        int width = image.width;
        int height = image.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixel = image.GetPixel(x, y);

                Vector3 pixelRGB = new Vector3(pixel.r, pixel.g, pixel.b);
                Vector3 targetRGB = new Vector3(targetColor.r, targetColor.g, targetColor.b);

                float distance = Vector3.Distance(pixelRGB, targetRGB);

                if (distance < tolerance)
                {
                    image.SetPixel(x, y, paintColor);
                }
            }
        }

        image.Apply();
    }


    private void OnDisable()
    {
        // Restaurar la textura original al salir del Play Mode
        Graphics.CopyTexture(originalImage, image);
    }
}
