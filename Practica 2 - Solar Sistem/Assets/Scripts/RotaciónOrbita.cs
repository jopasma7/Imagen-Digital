using UnityEngine;

public class RotacionOrbita : MonoBehaviour
{
    public float velocidad = 20f;

    void Update()
    {
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
    }
}