using UnityEngine;

public class NadoPecesMenu : MonoBehaviour
{
    [Header("Ajustes de Velocidad (Píxeles)")]
    [Tooltip("Pon un número positivo (ej. 150) para derecha, negativo (-150) para izquierda")]
    public float velocidadHorizontal = 150f; 
    
    [Header("Ajustes de Nado (Arriba y Abajo)")]
    [Tooltip("Cuántos píxeles sube y baja (ej. 50)")]
    public float amplitudNado = 50f; 
    [Tooltip("Qué tan rápido hace el zig-zag (ej. 1.5 o 2)")]
    public float velocidadNado = 1.5f; 

    [Header("Límites Infinitos (Canvas)")]
    public float limiteIzquierdo = -1100f;
    public float limiteDerecho = 1100f;

    private float posicionYInicial;

    void Start()
    {
        // Memorizamos la altura original del pez en las coordenadas del Canvas
        posicionYInicial = transform.localPosition.y;
    }

    void Update()
    {
        // 1. Calcular la nueva posición X (Avanzar hacia adelante)
        float nuevaX = transform.localPosition.x + (velocidadHorizontal * Time.deltaTime);

        // 2. Calcular la nueva posición Y (El efecto de flotación suave)
        float nuevaY = posicionYInicial + (Mathf.Sin(Time.time * velocidadNado) * amplitudNado);

        // Aplicamos la posición al pez usando localPosition
        transform.localPosition = new Vector3(nuevaX, nuevaY, transform.localPosition.z);

        // 3. Bucle infinito: Si sale de la pantalla, lo teletransportamos
        if (velocidadHorizontal > 0 && transform.localPosition.x > limiteDerecho)
        {
            transform.localPosition = new Vector3(limiteIzquierdo, posicionYInicial, transform.localPosition.z);
        }
        else if (velocidadHorizontal < 0 && transform.localPosition.x < limiteIzquierdo)
        {
            transform.localPosition = new Vector3(limiteDerecho, posicionYInicial, transform.localPosition.z);
        }
    }
}