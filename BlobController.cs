using UnityEngine;

public class BlobController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do personagem

    void Update()
    {
        // Obtém o input do teclado para movimentação
        float moveHorizontal = Input.GetAxis("Horizontal"); // WASD / Setas do teclado: esquerda e direita
        float moveVertical = Input.GetAxis("Vertical"); // WASD / Setas do teclado: cima e baixo

        // Cria um vetor de movimento com base nos inputs
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Aplica o movimento ao personagem
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
