using UnityEngine;

public class MovimientoPez : MonoBehaviour
{
    [Header("Velocidad y Dirección")]
    [Tooltip("Usa números positivos (ej. 150) para derecha, y negativos (ej. -150) para izquierda")]
    public float velocidad = 150f; // ¡Ahora usamos números grandes porque son píxeles!

    [Header("Límites de la Pantalla (Canvas)")]
    public float limiteIzquierdo = -1100f;
    public float limiteDerecho = 1100f;

    void Update()
    {
        // 1. Mover el pez en píxeles
        transform.localPosition += Vector3.right * velocidad * Time.deltaTime;

        // 2. Teletransportarlo al otro lado usando las coordenadas del Canvas
        if (velocidad > 0 && transform.localPosition.x > limiteDerecho)
        {
            transform.localPosition = new Vector3(limiteIzquierdo, transform.localPosition.y, transform.localPosition.z);
        }
        else if (velocidad < 0 && transform.localPosition.x < limiteIzquierdo)
        {
            transform.localPosition = new Vector3(limiteDerecho, transform.localPosition.y, transform.localPosition.z);
        }
    }
}