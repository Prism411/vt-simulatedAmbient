using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 45, 0); // Velocidade de rotação em graus por segundo

    void Update()
    {
        // Rotaciona o objeto continuamente
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
