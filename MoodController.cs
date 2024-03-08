using UnityEngine;

public class MoodController : MonoBehaviour
{
    public GameObject surpriseObject;
    public GameObject smileObject;
    public GameObject sadObject;
    public GameObject angryObject;
    public GameObject attentiveObject;
    public GameObject normalObject; //EYES
    public GameObject sleepyObject;
    public GameObject tediousObject;
    public GameObject mouthObject;

    public GameObject bodyObject;
    public GameObject headObject;
    public int state;
    private void Start()
    {
        // Esconde todos os humores no início
        HideAllMoods();
    }
    private void HideAllMoods()
    {
        surpriseObject.SetActive(false);  // estado 2
        smileObject.SetActive(false); // estado 3
        sadObject.SetActive(false); //estado 5
        angryObject.SetActive(false); //estado 7
        attentiveObject.SetActive(false); // estado 1
        sleepyObject.SetActive(false); //estado 6
        tediousObject.SetActive(false); //estado 4

        normalObject.SetActive(true); //estado 0 
        mouthObject.SetActive(true); //estado 0
    }
    // Método público para alterar o humor para Surpresa
public void setAttentive(){
        normalObject.SetActive(false);
        mouthObject.SetActive(true);
        attentiveObject.SetActive(true);
}
public void setSmile(){
        normalObject.SetActive(true);
        mouthObject.SetActive(true);
        smileObject.SetActive(true);
}
public void setTedious(){
        normalObject.SetActive(false);
        mouthObject.SetActive(false);
        tediousObject.SetActive(true);
}
public void setSleepy(){
        normalObject.SetActive(false);
        mouthObject.SetActive(false);
        sleepyObject.SetActive(true);
}
public void setSad(){
        normalObject.SetActive(true);
        mouthObject.SetActive(true);
        sadObject.SetActive(true);
}
public void setAngry(){
        normalObject.SetActive(true);
        mouthObject.SetActive(true);
        angryObject.SetActive(true);
}
public void setSurprise(){
        normalObject.SetActive(true);
        mouthObject.SetActive(false);
        surpriseObject.SetActive(true);
}

public int MoodChanger(float interest, float laziness, float commitment){
    bodyObject.SetActive(true);
    headObject.SetActive(true);
    // Desativa todos os estados de humor inicialmente
    surpriseObject.SetActive(false);
    smileObject.SetActive(false);
    sadObject.SetActive(false);
    angryObject.SetActive(false);
    attentiveObject.SetActive(false);
    sleepyObject.SetActive(false);
    tediousObject.SetActive(false);
    mouthObject.SetActive(true);
    normalObject.SetActive(true); // O estado normal é o padrão

    if (interest >= 80) {
        // Se o interesse for maior ou igual a 80, o humor é atento
        setAttentive();
        state = 1;
    } else if (interest >= 60) {
        int randomChoice = Random.Range(0,3);
        switch (randomChoice){
            case 1:
                setSmile();
                state = 3;
                break;
            case 2: 
                setSurprise();
                state = 2;
                break;
        }
    } else if (interest >= 40) {
        HideAllMoods();
        state = 0;
    } else if (interest == 35) {
        // Se o interesse for exatamente 35, escolhe aleatoriamente entre tedious, sleepy ou sad
        int randomChoice = Random.Range(0, 3); // Gera um número aleatório entre 0 e 2
        switch (randomChoice) {
            case 0:
                setTedious();
                state = 4;
                //estado 4
                break;
            case 1:
                setSleepy();
                state = 6;
                //estado 6
                break;
            case 2:
                setSad();
                state = 5;
                //estado 5
                break;
        }
    } else if (interest < 35 && interest >= 10) {
        // Se o interesse estiver entre 10 (inclusive) e 35, ajusta conforme o caso de 35
        normalObject.SetActive(false);
        int randomChoice = Random.Range(0, 3); // Gera um número aleatório entre 0 e 2
        switch (randomChoice) {
            case 0:
                setTedious();
                state = 4;
                //estado 4
                break;
            case 1:
                setSleepy();
                state = 6;
                //estado 6
                break;
            case 2:
                setSad();
                state = 5;
                //estado 5
                break;
        }
    } else if (interest < 10) {
        // Se o interesse for menor que 10, o humor é irritado
        setAngry();
        //estado 7
        state = 7;
    }
    if ((interest < 30) & (commitment < 50)){
       int randomChance = Random.Range(0,3);
       if (randomChance == 2){
            bodyObject.SetActive(false);
            headObject.SetActive(false);
            HideAllMoods();
            normalObject.SetActive(false);
            mouthObject.SetActive(false);
        state = 8;
    }}
    return state;
}

}
