using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PreePulse : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Teksti;

    float timer;
    bool BtnPressed = false;

    [SerializeField] Color Col1, Col2;

    void Update ()
    {
        if(BtnPressed == true){
            BtnPulse(timer);
        }
        timer += Time.deltaTime; 
        if (timer <= 0.5 || BtnPressed == true)
        { 
            Teksti.color = new Color(Teksti.color.r,Teksti.color.g,Teksti.color.b,1f);
        } 
        else if (timer <= 1)
        { 
            Teksti.color = new Color(Teksti.color.r,Teksti.color.g,Teksti.color.b,0f);
        } else {
            timer = 0; 
        }

        if (Input.anyKey && BtnPressed == false){
            Invoke("ScreenFade", 0.4f);
            Invoke("SwitchScene", 2f);
            timer = 0f;
            BtnPressed = true;
        }
    }

    void BtnPulse(float t){
        if (t <= 0.02f || (t > 0.12f && t <= 0.22f ) || (t > 0.32f && t <= 0.42f )){
            Teksti.color = Col1;
        } else {
            Teksti.color = Col2;
        }
    }

    void SwitchScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ScreenFade(){
        Fade.RequestFade = true;
    }
}
