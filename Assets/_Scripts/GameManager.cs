using UnityEngine;
using UnityEngine.UI; // Necesario para controlar textos de UI
using UnityEngine.SceneManagement; // Necesario para cambiar de niveles/escenas

public class GameManager : MonoBehaviour
{
    public int vidas = 3;
    
    [Header("Elementos de UI")]
    public Text textoVidas; 
    public GameObject panelGameOver;

    void Start()
    {
        // Asegurarnos de que el tiempo corre normal al iniciar
        Time.timeScale = 1f; 
        panelGameOver.SetActive(false); 
        ActualizarTextoVidas();
    }

    public void PerderVida()
    {
        vidas--;
        ActualizarTextoVidas();

        if (vidas <= 0)
        {
            TerminarJuego();
        }
    }

    void ActualizarTextoVidas()
    {
        textoVidas.text = "Vidas: " + vidas;
    }

    void TerminarJuego()
    {
        // ¡Magia! Esto congela todo lo que usa Time.deltaTime (caídas, generadores)
        Time.timeScale = 0f; 
        
        // Mostramos la pantalla
        panelGameOver.SetActive(true);
    }

    // --- FUNCIONES PARA LOS BOTONES ---
    public void Reintentar()
    {
        Time.timeScale = 1f; // Descongelar el tiempo
        // Recarga el nivel actual en el que estamos
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f; // Descongelar el tiempo
        // ¡OJO! Asegúrate de que este nombre sea exactamente igual al de tu escena de menú
        SceneManager.LoadScene("MenuPrincipal"); 
    }
}