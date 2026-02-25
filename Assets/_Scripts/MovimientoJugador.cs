using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody2D rb;

    void Start()
    {
        // Buscamos el componente de física automáticamente
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Movimiento Horizontal (Teclas A/D o Flechas)
        float movimientoX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoX * velocidad, rb.velocity.y);

        // 2. Salto (Tecla Espacio)
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
    // Esta función se ejecuta automáticamente cuando el jugador toca un Trigger
void OnTriggerEnter2D(Collider2D other)
    {
        // ¿Lo que tocamos tiene la etiqueta "Enemy"?
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("¡He tocado basura! Aquí iniciaría el minijuego.");
            // Aquí más adelante pausaremos el juego y mostraremos la pregunta.
            // Por ahora, solo destruimos el enemigo para probar.
            Destroy(other.gameObject);
        }
    }
}