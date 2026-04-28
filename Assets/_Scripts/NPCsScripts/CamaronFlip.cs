using UnityEngine;
using UnityEngine.UI;

public class CamaronFlip : MonoBehaviour
{
    [Header("Configuración")]
    public float intervaloFlip = 3f; // Segundos entre giro

    private float timer = 0f;
    private bool vieneDerecha = true;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervaloFlip)
        {
            Flip();
            timer = 0f;
        }
    }

    void Flip()
    {
        vieneDerecha = !vieneDerecha;

        Vector3 scale = rectTransform.localScale;
        scale.x *= -1;
        rectTransform.localScale = scale;
    }
}