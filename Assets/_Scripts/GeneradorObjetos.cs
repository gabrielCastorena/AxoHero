using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    [Header("Objetos a generar")]
    public GameObject[] objetosParaAparecer; // Aquí guardaremos la botella y la estrella

    [Header("Configuración")]
    public float tiempoEntreApariciones = 1.5f; // Cada cuántos segundos cae algo
    public float limiteIzquierdo = -8f; // Qué tan a la izquierda puede aparecer
    public float limiteDerecho = 8f;    // Qué tan a la derecha puede aparecer

    void Start()
    {
        // Esta función mágica repite la creación de objetos una y otra vez
        InvokeRepeating("CrearObjeto", 1f, tiempoEntreApariciones);
    }

    void CrearObjeto()
    {
        // 1. Elegimos al azar qué tirar (¿basura o naturaleza?)
        int indiceAleatorio = Random.Range(0, objetosParaAparecer.Length);
        GameObject objetoElegido = objetosParaAparecer[indiceAleatorio];

        // 2. Elegimos una posición X al azar (de izquierda a derecha)
        float posicionXAleatoria = Random.Range(limiteIzquierdo, limiteDerecho);
        
        // 3. Calculamos el punto exacto de aparición
        // Usamos la 'Y' (altura) del Generador invisible
        Vector3 posicionAparicion = new Vector3(posicionXAleatoria, transform.position.y, 0);

        // 4. ¡Hacemos que aparezca en el juego!
        Instantiate(objetoElegido, posicionAparicion, Quaternion.identity);
    }
}