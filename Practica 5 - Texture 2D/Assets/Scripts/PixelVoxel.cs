using UnityEngine;
using UnityEngine.InputSystem;

public class PixelVoxel : MonoBehaviour
{
    public Texture2D image;          // Imagen a convertir en voxels
    public GameObject cubePixel;     // Prefab del cubo
    private GameObject[,] voxels;    // Para guardar los cubos creados

    private int width;
    private int height;

    private void Start()
    {
        if (image == null || cubePixel == null)
        {
            Debug.LogError("Faltan referencias en el inspector.");
            return;
        }

        width = image.width;
        height = image.height;

        voxels = new GameObject[width, height];

        GenerateVoxels();
    }

    private void GenerateVoxels()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixel = image.GetPixel(x, y);

                // Ignorar píxeles transparentes
                if (pixel.a == 0)
                    continue;

                // Crear cubo
                Vector3 pos = new Vector3(x, y, 0);
                GameObject cube = Instantiate(cubePixel, pos, Quaternion.identity);

                // Aplicar color del píxel al cubo
                Renderer r = cube.GetComponent<Renderer>();
                if (r != null)
                    r.material.color = pixel;

                // Guardarlo para destruirlo luego
                voxels[x, y] = cube;
            }
        }
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (voxels[x, y] != null)
                    {
                        Rigidbody rb = voxels[x, y].AddComponent<Rigidbody>();
                        rb.useGravity = true;
                    }
                }
            }
        }
    }

}
