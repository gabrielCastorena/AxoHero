using UnityEngine;

public class ConchaFlotante : MonoBehaviour
{
    [Header("Ajustes de Flotación")]
    public float velocidadHorizontal = 2f;
    public float amplitudFlote = 0.5f; // Qué tanto sube y baja
    public float velocidadFlote = 2f;  // Qué tan rápido sube y baja
    
    private float posicionYInicial;
    private int direccion = -1; // -1 significa que va hacia la izquierda

    void Start()
    {
        // Guardamos su altura inicial para que flote alrededor de ese punto
        posicionYInicial = transform.position.y;
        
        // Se destruye solita después de 12 segundos para no llenar la memoria
        Destroy(gameObject, 12f); 
    }

    void Update()
    {
        // 1. Calcular nueva posición X (avanzar a la izquierda)
        float nuevaX = transform.position.x + (direccion * velocidadHorizontal * Time.deltaTime);
        
        // 2. Calcular nueva posición Y (El efecto de flotar)
        float nuevaY = posicionYInicial + (Mathf.Sin(Time.time * velocidadFlote) * amplitudFlote);

        // Aplicar el movimiento
        transform.position = new Vector3(nuevaX, nuevaY, transform.position.z);
    }

    // --- AQUÍ ESTÁ LA MAGIA DEL CLIC TRASPLANTADA ---
    void OnMouseDown()
    {
        Debug.Log("¡Cuidado! La concha es de la naturaleza.");
        
        // Buscar al mánager y quitar una vida
        FindObjectOfType<GameManager>().PerderVida();
        
        // Destruir la concha cuando le das clic
        Destroy(gameObject); 
    }
}