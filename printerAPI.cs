using System.Collections;
using UnityEngine;

public class PrinterAPI : MonoBehaviour
{
    public void CaptureScreenshot()
    {
        // Gera o nome do arquivo baseado na data e hora para evitar sobreposição de nomes
        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        // Define o caminho relativo dentro do diretório do projeto/jogo
        string folderPath = "dataControl/";
        
        // Verifica e cria a pasta se ela não existir
        if (!System.IO.Directory.Exists(Application.dataPath + "/" + folderPath))
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + "/" + folderPath);
        }
        
        // Caminho completo para salvar a screenshot
        string fullPath = Application.dataPath + "/" + folderPath + fileName;

        // Captura a screenshot e salva no caminho especificado
        ScreenCapture.CaptureScreenshot(fullPath);
        // Debug.Log("Screenshot saved as: " + fullPath);
    }
}
