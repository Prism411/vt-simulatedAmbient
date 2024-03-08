using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCreator : MonoBehaviour
{
    public GameObject body; // Referência ao componente Body
    public GameObject head; // Referência ao componente Head

    // Start is called before the first frame update
    void Start()
    {
        // Define uma cor aleatória para o Body
        if (body != null)
        {
            Renderer bodyRenderer = body.GetComponent<Renderer>();
            if (bodyRenderer != null)
            {
                bodyRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }

        // Define uma cor aleatória para o Head
        if (head != null)
        {
            Renderer headRenderer = head.GetComponent<Renderer>();
            if (headRenderer != null)
            {
headRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
