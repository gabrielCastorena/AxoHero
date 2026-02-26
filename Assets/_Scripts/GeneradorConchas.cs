using UnityEngine;

public class GeneradorConchas : MonoBehaviour
{
    public GameObject conchaPrefab;
    public float tiempoEntreSpawns = 4f; // Sale una cada 4 segundos
    public float alturaMinima = -4f; // Límite de abajo (cerca de la arena)
    public float alturaMaxima = 1f;  // Límite de arriba (debajo de la tabla)

    void Start()
    {
        InvokeRepeating("CrearConcha", 2f, tiempoEntreSpawns);
    }

    void CrearConcha()
    {
        // Elegimos una altura aleatoria en el agua
        float yAleatoria = Random.Range(alturaMinima, alturaMaxima);
        Vector3 posicionSpawn = new Vector3(transform.position.x, yAleatoria, 0);
        
        Instantiate(conchaPrefab, posicionSpawn, Quaternion.identity);
    }
}