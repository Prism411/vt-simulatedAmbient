using UnityEngine;

public class CharacteristicsGenerator : MonoBehaviour
{
    public GameObject BodyObject;
    public GameObject HeadObject;

    // Intervalos de escala para o corpo
    public float minBodyWidthMultiplier = 0.9f;
    public float maxBodyWidthMultiplier = 1.1f;
    public float minBodyHeightMultiplier = 0.95f; // Para "achatar" o corpo
    public float maxBodyHeightMultiplier = 1.05f;

    // Intervalos de escala para a cabeça
    public float minHeadSizeMultiplier = 0.95f;
    public float maxHeadSizeMultiplier = 1.05f;

    // Intervalos de escala para altura geral do personagem
    public float minHeightMultiplier = 0.95f;
    public float maxHeightMultiplier = 1.05f;

    void Start()
    {
        RandomizeCharacteristics();
    }

    void RandomizeCharacteristics()
    {
        // Randomiza a largura e altura do corpo
        float bodyWidthMultiplier = Random.Range(minBodyWidthMultiplier, maxBodyWidthMultiplier);
        float bodyHeightMultiplier = Random.Range(minBodyHeightMultiplier, maxBodyHeightMultiplier);
        Vector3 bodyScale = BodyObject.transform.localScale;
        bodyScale.x *= bodyWidthMultiplier; // Ajusta a largura (eixo X)
        bodyScale.y *= bodyHeightMultiplier; // Ajusta a altura (eixo Y) para "achatar"
        BodyObject.transform.localScale = bodyScale;

        // Randomiza o tamanho da cabeça (largura e altura)
        float headSizeMultiplier = Random.Range(minHeadSizeMultiplier, maxHeadSizeMultiplier);
        Vector3 headScale = HeadObject.transform.localScale;
        headScale.x *= headSizeMultiplier; // Ajusta a largura (eixo X)
        headScale.y *= headSizeMultiplier; // Ajusta a altura (eixo Y)
        HeadObject.transform.localScale = headScale;

        // Randomiza a altura geral do personagem (Body + Head)
        float heightMultiplier = Random.Range(minHeightMultiplier, maxHeightMultiplier);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * heightMultiplier, transform.localScale.z);
    }
}
