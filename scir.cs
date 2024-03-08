using UnityEngine;

public class scir : MonoBehaviour
{
    void Start()
    {
        // Encontra o componente Body dentro de Glob
        Transform bodyTransform = transform.Find("Body");
        if (bodyTransform != null)
        {
            Renderer bodyRenderer = bodyTransform.GetComponent<Renderer>();
            if (bodyRenderer != null)
            {
                // Aplica uma cor aleatória ao Body
                bodyRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }

        // Encontra o componente Head dentro de Glob
        Transform headTransform = transform.Find("Head");
        if (headTransform != null)
        {
            Renderer headRenderer = headTransform.GetComponent<Renderer>();
            if (headRenderer != null)
            {
                // Aplica uma cor aleatória ao Head
                headRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
