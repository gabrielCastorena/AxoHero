using UnityEngine;

public class PezNadador : MonoBehaviour
{
    public float velocidad = 200f;       // Qué tan rápido nada
    public float limiteDerecho = 1200f;  // La meta (donde desaparece)
    public float inicioIzquierdo = -1200f; // El inicio (donde reaparece)

    private RectTransform miRectangulo;

    void Start()
    {
        // Agarramos el componente que controla la posición en UI
        miRectangulo = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 1. Mover hacia la derecha (eje X)
        miRectangulo.anchoredPosition += new Vector2(velocidad * Time.deltaTime, 0);

        // 2. Revisar si ya se salió de la pantalla por la derecha
        if (miRectangulo.anchoredPosition.x > limiteDerecho)
        {
            // 3. Teletransportarlo a la izquierda
            Vector2 nuevaPosicion = miRectangulo.anchoredPosition;
            nuevaPosicion.x = inicioIzquierdo;
            miRectangulo.anchoredPosition = nuevaPosicion;
        }
    }
}