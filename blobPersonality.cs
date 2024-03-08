using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPersonality : MonoBehaviour
{
    public string blobName; // Nome do blob
    public float blobInterest; // Valor que muda ao longo do tempo que determina o interesse atual do Blob na atividade.
    public float blobLaziness; // Característica específica: isso aqui é a taxa que diminui ao longo do tempo no Interest
    public float blobCommitment; // O peso que junta as peças entre Laziness e Interest

    private List<string> nomes = new List<string> { "Jader", "Wyllgner", "Nicolas", "Lucas","Gustavo","Andrey","João","Samih","Mario","Alexandre","Caio","Tifon","Gabriel","Bernado","Noah","Levi","Benjamim","Miguel","Arthur","Matheus","Samuel","Daniel","Enzo","Lucca","Pedro","Thales","Raian","Akira","Satoru","Oddy","Charles","Max","Fernando","Carlos"};
    private List<string> sobrenomes = new List<string> { "Louis", "Amorim", "Sales", "Marques","Oliveira","Riça","Marcos","Santos","Reis","Dantas","Torquato","Souza","Bonaviga","Xuint","Tavares","Gonçalves","Moreira","Lisboa","Rodrigues","Fernandes","Cardoso","Rian","Gojo","Leclerc","Verstappen","Alonso","Sainz"};

    void Start()
    {

        // Imprime os valores no Console do Unity
        //Debug.Log($"Interesse: {blobInterest}");
        //Debug.Log($"Preguiça: {blobLaziness}");
        // Debug.Log($"Comprometimento: {blobCommitment}");
    }
    public void generate(){
        blobName = GerarNomeBlob();
        blobInterest = UnityEngine.Random.Range(25f, 80f);
        blobLaziness = UnityEngine.Random.Range(20f, 90f);
        blobCommitment = UnityEngine.Random.Range(0f, 100f);
    }
    // Função para gerar um nome aleatório
    public string GerarNomeBlob()
    {
        int nomeIndex = UnityEngine.Random.Range(0, nomes.Count);
        int sobrenomeIndex = UnityEngine.Random.Range(0, sobrenomes.Count);

        // Combina o nome e sobrenome para formar o nome do blob
        return $"{nomes[nomeIndex] } {sobrenomes[sobrenomeIndex]}";
    }
}
