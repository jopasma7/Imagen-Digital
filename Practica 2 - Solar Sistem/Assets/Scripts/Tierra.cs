using UnityEngine;

public class RotacionPropia : MonoBehaviour
{
    public float velocidad = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
    }
}