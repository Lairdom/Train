using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PreePulse : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Teksti, Logo, Er;

    float timer;
    bool BtnPressed = false;
    float StartTime;
    float Pressed = 0f;

    [SerializeField] Color Col1, Col2;
    void Awake(){
        Pressed = 0f;
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
            Pressed = 0f;
            BtnPressed = true;
        }
        if (BtnPressed == true){
            Pressed += Time.deltaTime;
            Teksti.color = Color.Lerp(
                new Color(Teksti.color.r,Teksti.color.g,Teksti.color.b,1f),
                new Color(0f,0f,0f,1f), Pressed/1.5f);

            Er.color = Color.Lerp(
                new Color(Er.color.r,Er.color.g,Er.color.b,1f),
                new Color(0f,0f,0f,1f), Pressed/1.5f);

            Logo.color = Color.Lerp(
                new Color(Logo.color.r,Logo.color.g,Logo.color.b,1f),
                new Color(0f,0f,0f,1f), Pressed/1.5f);
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
