using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    // 1. Botón JUGAR (Va al Nivel 1 o al último guardado)
    public void Jugar()
    {
        SceneManager.LoadScene("NivelEjemplo");
    }

    // 2. Botón NIVELES (Irá a una escena de selección de nivel)
    public void IrANiveles()
    {
        // Por ahora solo imprime un mensaje hasta que crees la escena
        Debug.Log("Yendo a selección de niveles...");
        // SceneManager.LoadScene("MenuNiveles"); // Descomenta esto cuando crees la escena
    }

    // 3. Botón AJUSTES (Abrirá un panel o escena de configuración)
    public void IrAConfiguracion()
    {
        Debug.Log("Abriendo configuración...");
        // Aquí activaremos un Panel de UI más adelante
    }
}