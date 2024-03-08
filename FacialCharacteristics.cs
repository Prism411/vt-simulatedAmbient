using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialCharacteristics : MonoBehaviour
{
    public GameObject mainEye; // Para randomizar o tamanho do olho.

    void Start()
    {
        RandomizeEyeSize();
    }

void RandomizeEyeSize()
{
    float minScale = 0.9f; // Mínimo de 90% do tamanho original
    float maxScale = 1.1f; // Máximo de 110% do tamanho original

    float newScale = Random.Range(minScale, maxScale);


    mainEye.transform.localScale = new Vector3(newScale, newScale, newScale);

    // Se necessário, ajustar a posição aqui para compensar a mudança de escala
    // Isso pode envolver cálculos adicionais dependendo da configuração do seu objeto
    // Por exemplo, você poderia tentar ajustar a posição local para manter a posição relativa constante

}
}