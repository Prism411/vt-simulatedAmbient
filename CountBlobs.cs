using UnityEngine;

public class CountAllBlobs : MonoBehaviour
{
    void Start()
    {
// Conta todos os objetos com a tag "Blob"
        GameObject[] blobsWithTag = GameObject.FindGameObjectsWithTag("Blob");

        foreach (GameObject blob in blobsWithTag)
        {
            if (blob.name.Contains("blobPrefab"))
            {
                // Acessa o componente BlobPersonality do blob
                BlobPersonality personality = blob.GetComponent<BlobPersonality>();
                
                // Verifica se o blob tem o componente BlobPersonality
                if (personality != null)
                {
                    // Imprime o nome armazenado no script BlobPersonality
                    Debug.Log($"Nome do Blob: {personality.blobName}");
                }
                else
                {
                    Debug.Log($"BlobPersonality não encontrado no objeto {blob.name}");
                }
            }
        }
    }
}
