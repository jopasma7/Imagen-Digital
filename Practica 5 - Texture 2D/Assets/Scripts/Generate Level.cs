using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public Texture2D image;          // Imagen a leer
    public GameObject cubeWall;      // Prefab del cubo
    public Transform parent;         // Objeto padre donde colocar los cubos

    private int width;
    private int height;

    private void Start()
    {
        if (image == null || cubeWall == null || parent == null)
        {
            Debug.LogError("Faltan referencias en el inspector.");
            return;
        }

        width = image.width;
        height = image.height;

        Generate();
    }

    private void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixelColor = image.GetPixel(x, y);

                // Si el píxel es transparente, no generamos nada
                if (pixelColor.a == 0)
                    continue;

                // Si el píxel es negro, generamos un cubo
                if (pixelColor == Color.black)
                {
                    Vector3 position = new Vector3(x, y, 0);
                    Instantiate(cubeWall, position, Quaternion.identity, parent);
                }
            }
        }
    }
}
