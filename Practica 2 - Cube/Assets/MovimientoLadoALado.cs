using UnityEngine;

public class MovimientoLadoALado : MonoBehaviour
{
    public float velocidad = 3f;
    public float distancia = 10f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float movimiento = Mathf.PingPong(Time.time * velocidad, distancia) - (distancia / 2f);
        transform.position = posicionInicial + new Vector3(movimiento, 0, 0);
    }
}
