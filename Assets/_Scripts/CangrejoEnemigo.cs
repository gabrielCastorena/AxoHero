using UnityEngine;

public class CangrejoEnemigo : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 3f;
    public float limiteIzquierdo = -7f;
    public float limiteDerecho = 7f;
    private int direccion = 1; // 1 es derecha, -1 es izquierda

    [Header("Ataque de Basura")]
    public GameObject botellaPrefab; // Aquí pondremos tu prefab de la botella
    public float tiempoEntreLanzamientos = 2f; // Cada cuántos segundos tira una botella

    void Start()
    {
        // Esta función mágica repite un ataque cada X segundos automáticamente
        InvokeRepeating("TirarBasura", 1f, tiempoEntreLanzamientos);
    }

    void Update()
    {
        // 1. Mover al cangrejo
        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);

        // 2. Comprobar si chocó con los límites invisibles para dar la vuelta
        if (transform.position.x >= limiteDerecho) 
        {
            direccion = -1; // Cambia a la izquierda
        } 
        else if (transform.position.x <= limiteIzquierdo) 
        {
            direccion = 1; // Cambia a la derecha
        }
    }

    void TirarBasura()
    {
        // Crea una copia de la botella exactamente en la posición donde esté el cangrejo
        Instantiate(botellaPrefab, transform.position, Quaternion.identity);
    }
}