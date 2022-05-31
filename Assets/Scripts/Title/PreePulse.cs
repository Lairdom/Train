using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PreePulse : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Teksti;

    float timer;
    bool BtnPressed = false;
    float StartTime;

    [SerializeField] Color Col1, Col2;
    void Awake(){
        StartTime = 0;
        Teksti.color = new Color(Teksti.color.r,Teksti.color.g,Teksti.color.b,0f);
    }

    void Update ()
    {
        StartTime += Time.deltaTime;
        if(BtnPressed == true){
            BtnPulse(timer);
        }
        if(StartTime > 10f){
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
        }

        if (Input.anyKey && BtnPressed == false && StartTime > 10f){
            Invoke("ScreenFade", 2f);
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
