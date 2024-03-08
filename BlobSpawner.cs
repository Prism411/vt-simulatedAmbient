using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine;

public class BlobSpawner : MonoBehaviour
{
    public GameObject blobPrefab;
    public List<BlobPersonality> blobPersonalities = new List<BlobPersonality>();
    public List<BlobBehavior> blobBehaviors = new List<BlobBehavior>();
    private List<GameObject> spawnedBlobs = new List<GameObject>(); // Lista para manter referência dos blobs instanciados

    float y = 4.37f;
    float[] zs = new float[] { -15.14195f, -13.14195f, -10.12287f };
    float[] xs = new float[] { 7.73567f, 9.73567f, 11.73567f, 13.73567f, 15.73567f };

    void Start()
    {
                // Inicia a coroutine
        StartCoroutine(SaveBlobBehaviorsToCSVPeriodically());
        GenerateBlobs(); // Chama a função de geração na inicialização
    }
    void GenerateBlobs()
    {

        foreach (float z in zs)
        {
            foreach (float x in xs)
            {
                GameObject blobInstance = Instantiate(blobPrefab, new Vector3(x, y, z), Quaternion.Euler(10, 90, 0));
                BlobPersonality personality = blobInstance.GetComponent<BlobPersonality>();
                BlobBehavior behavior = blobInstance.GetComponent<BlobBehavior>();
                personality.generate();
                behavior.Start();

                if (personality != null)
                {
                    blobPersonalities.Add(personality);
                    blobBehaviors.Add(behavior);
                }
                spawnedBlobs.Add(blobInstance); // Adiciona a instância à lista de blobs instanciados
            }
        }
    }

    IEnumerator SaveBlobBehaviorsToCSVPeriodically()
    {
        while (true)
        {
            SaveBlobBehaviorsToCSV();
           // daysCount++;
            //if (daysCount == 8){
           //     daysCount = 0;
             //   RegenerateBlobs();
            
            yield return new WaitForSeconds(3); // Espera por 3 segundos
        }
    }
// Função modificada para criar e salvar um CSV
public void SaveBlobBehaviorsToCSV()
{
    StringBuilder sb = new StringBuilder();
    // Define o caminho absoluto para a pasta onde as imagens e o CSV serão salvos
    string folderPath = @"C:\Users\jader\Desktop\estudos\visage-track\vt-iamodel\ambientInfo";

    // Verifica e cria a pasta se ela não existir
    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }

    // Especifica o caminho completo e o nome do arquivo onde o CSV será salvo
    string filePath = Path.Combine(folderPath, "BlobBehaviors.csv");

    // Verifica se o arquivo já existe para adicionar o cabeçalho apenas se for um novo arquivo
    if (!File.Exists(filePath))
    {
        // Adiciona o cabeçalho do CSV apenas uma vez
        sb.AppendLine("FileName;Blob Name;Estado;Dias Passados;Interest;Laziness;Commitment");
    }
    int i = 0;
    string filename = "";
    // Presume-se que behavior.CaptureScreenshot() retorne o nome do arquivo da imagem 
    foreach (BlobBehavior behavior in blobBehaviors)
    {
        if (i == 0){
            i++;
            filename = behavior.CaptureScreenshot();
            Debug.Log($"Imagem em em: {filename}");
        }
        // Adiciona uma linha para cada BlobBehavior
        sb.AppendLine($"{filename};{behavior.blobName};{behavior.state};{behavior.daysCount};{behavior.interest};{behavior.laziness};{behavior.commitment}");
    }
    i = 0;

    // Anexa a string CSV ao arquivo, criando-o se não existir
    File.AppendAllText(filePath, sb.ToString());

    Debug.Log($"CSV anexado em: {filePath}");
}

    // Função para deletar e regenerar blobs
    public void RegenerateBlobs()
    {
        // Deleta os blobs existentes
        foreach (GameObject blob in spawnedBlobs)
        {
            Destroy(blob);
        }
        spawnedBlobs.Clear(); // Limpa a lista de referências
        blobPersonalities.Clear(); // Limpa a lista de personalidades
        blobBehaviors.Clear(); // Limpa a lista de comportamentos

        GenerateBlobs(); // Gera novos blobs
    }


}