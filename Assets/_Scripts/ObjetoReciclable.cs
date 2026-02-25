using UnityEngine;

public class ObjetoReciclable : MonoBehaviour
{
    public bool esBasura; 
    
    [Header("Configuración de Caída")]
    public float velocidadCaida = 3f; 
    public float limiteAbajo = -7f;

    [Header("Efecto Animado (Agua)")]
    public float amplitudOscilacion = 1.5f; // Qué tan ancho es el zig-zag
    public float velocidadOscilacion = 2f;  // Qué tan rápido se mece de lado a lado
    public float velocidadRotacion = 50f;   // Qué tan rápido gira sobre sí mismo

    private float posicionXInicial;

    void Start()
    {
        // Guardamos dónde apareció el objeto para que oscile alrededor de este punto
        posicionXInicial = transform.position.x;
    }

    void Update()
    {
        // 1. Calcular la nueva posición hacia abajo
        float nuevaY = transform.position.y - (velocidadCaida * Time.deltaTime);

        // 2. Calcular el zig-zag (El efecto retro/animado)
        // Mathf.Sin crea una curva suave perfecta para simular que flota en el agua
        float nuevaX = posicionXInicial + Mathf.Sin(Time.time * velocidadOscilacion) * amplitudOscilacion;

        // Aplicamos la nueva posición
        transform.position = new Vector3(nuevaX, nuevaY, transform.position.z);

        // 3. Rotación suave para que no parezca un cartón tieso
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);

        // 4. Limpieza automática
        if (transform.position.y < limiteAbajo)
        {
            Destroy(gameObject);
        }
    }

void OnMouseDown()
    {
        if (esBasura)
        {
            Debug.Log("¡Bien hecho! Basura reciclada.");
            Destroy(gameObject); 
        }
        else
        {
            Debug.Log("¡Cuidado! Eso es de la naturaleza.");
            // Buscar al árbitro y quitar una vida
            FindObjectOfType<GameManager>().PerderVida();
            
            // Opcional: Destruir el objeto de naturaleza para que sepas que le diste clic
            Destroy(gameObject); 
        }
    }
}