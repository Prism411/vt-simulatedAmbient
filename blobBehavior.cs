using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine;
public class BlobBehavior : MonoBehaviour
{
    // Tempo em segundos para esperar antes de reverter a rotação
    private readonly float waitTime = 3f;

    public float interest; // Valor que muda ao longo do tempo que determina o interesse atual do Blob na atividade.
    public float laziness; // Característica específica: isso aqui é a taxa que diminui ao longo do tempo no Interest
    public float commitment; // A variável que liga os dois

    public int daysCount;
    public int state;

    private float x;
    public float blobInterest;
    public string blobName;
    private int estadoSomaOuSub;
    BlobPersonality blobPersonality; 
    MoodController moodControl ;
    PrinterAPI printerApi;

    BlobSpawner blobspawner;

    public void Start()
    {       
            printerApi = GetComponent<PrinterAPI>();
            blobPersonality = GetComponent<BlobPersonality>();
            moodControl = GetComponent<MoodController>();
            interest = blobPersonality.blobInterest;
            blobInterest = blobPersonality.blobInterest;
            laziness = blobPersonality.blobLaziness;
            commitment = blobPersonality.blobCommitment;
            blobName = blobPersonality.blobName;
            daysCount = 0;
            StartCoroutine(UpdateInterest());
            //StartCoroutine(RotateBlob());


    }


    IEnumerator UpdateInterest()
    {

        // Loop enquanto o componente estiver ativo
        while (true)
        {
            // Espera 7 segundos
            yield return new WaitForSeconds(3f);
            //CaptureScreenshot();
                daysCount = daysCount+1;
                int daysSub = daysCount;
                if (daysCount >= 32){
                    daysSub = 31;
                }
            float taxaPraDiminuirEmLaziness = commitment/2 + ((laziness/(32-daysCount)));
            // Calcula a taxa para diminuir o interest baseado em laziness e commitment
            // Aplica a porcentagem de laziness para diminuir o interest
            if (commitment > 45f){
                x = (5/1+laziness) * (interest*taxaPraDiminuirEmLaziness/100f);
                estadoSomaOuSub = 1;
            }else{
                x = (laziness/10) * ((interest * taxaPraDiminuirEmLaziness / 1000f));
                estadoSomaOuSub = 0;
            }   
            if (x>10){
                x = 10;
            }
            if (estadoSomaOuSub == 1){
                blobInterest += x;
                //Debug.Log($"Blob: {blobName} teve um aumento de {x} no seu interesse!");
            }else{
                blobInterest -= x;
                //Debug.Log($"Blob: {blobName} teve um decremento de {x} no seu interesse!");
            }
            state = moodControl.MoodChanger(blobInterest,laziness,commitment);
            if ((state == 2)||(state ==1)){
                int randomChance = Random.Range(0,3);{
                    if (randomChance == 0){
                        laziness -= 20;
                    }
                    if (randomChance == 1){
                        blobInterest += 10;
                    }
                    if (randomChance == 2){
                        blobInterest -= 30;
                        laziness += 1;
                    }
                }
            }
            if (state == 6){
                int randomChance = Random.Range(0,3);
                if (randomChance == 2){
                    blobInterest += 50;
                }
            }
            if ((state == 7)||(state == 4)){
                int randomChance = Random.Range(0,3);{
                    if (randomChance == 0){
                        laziness += 20;
                    }
                    if (randomChance == 1){
                        blobInterest -= 15;
                    }
                    if (randomChance == 2){
                        blobInterest += 30;
                        laziness += 1;
                    }
                }
            }
            

            // Reset o interest após 1 minuto (60 segundos) simulando 1 dia
            // Verifica se passou 1 minuto desde o último reset
            if (Time.time % 30f < 3f) // Essa condição aproxima o conceito, mas não é precisa para longos períodos de tempo
            {   
            // Chance de modificação baseada em laziness
                float chance = Random.Range(0f, 100f);
                if (chance >= laziness){
                    blobInterest = interest - daysSub;
                }else{
                    blobInterest = interest + daysSub; // Reset o interest
                }
                commitment = Random.Range(10f, 90f); // Atualiza a taxa de commitment aleatoriamente
            }
            // Opcional: Atualizar o Debug.Log para monitorar os valores
        }
    }

    IEnumerator RotateBlob()
    {
        // Loop infinito
        while (true)
        {
            // Gera um ângulo aleatório de rotação
            float randomAngle = Random.Range(0f, 360f);
            // Rotaciona o blob para o ângulo aleatório
            transform.rotation = Quaternion.Euler(0, randomAngle, 0);

            // Espera por um determinado tempo
            yield return new WaitForSeconds(waitTime / 2f);
            // Retorna o blob para a rotação Y = 90
            transform.rotation = Quaternion.Euler(10, 90f, 0);
            // Espera novamente pelo mesmo tempo antes de repetir o ciclo
            yield return new WaitForSeconds(waitTime / 2f);
        }
    }
 public string CaptureScreenshot()
{
    // Gera o nome do arquivo baseado na data e hora para evitar sobreposição de nomes
    string fileName = "Screenshot_" + daysCount + ".png";
    // Define o caminho absoluto fora do diretório do projeto/jogo
    string folderPath = @"C:\Users\jader\Desktop\estudos\visage-track\vt-iamodel\images";

    // Verifica e cria a pasta se ela não existir
    if (!System.IO.Directory.Exists(folderPath))
    {
        System.IO.Directory.CreateDirectory(folderPath);
    }
    
    // Caminho completo para salvar a screenshot
    string fullPath = System.IO.Path.Combine(folderPath, fileName);

    // Captura a screenshot e salva no caminho especificado
    ScreenCapture.CaptureScreenshot(fullPath);
    return fileName;
    //Debug.Log("Screenshot saved as: " + fullPath);
}

}
