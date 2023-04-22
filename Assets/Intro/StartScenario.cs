using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenario : MonoBehaviour
{
    //페이드 인 아웃 시스템을 관리
    bool IsItFade = true;

    GameObject Canvas;

    GameObject[] Intro_subtitle = new GameObject[4];
    GameObject[] Scenes = new GameObject[4];

    AudioSource[] Intro_Sounds = new AudioSource[4];

    AudioSource BGM;

    int index;

    public GameObject FadeSystem;
    public GameObject Stage1;
    public GameObject mail;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("First_bgm").GetComponent<AudioSource>();
        BGM.Play();

        index = 0;

        Canvas = GameObject.Find("Canvas");

        Intro_subtitle[0] = Canvas.transform.GetChild(0).gameObject;
        Intro_Sounds[0] = Intro_subtitle[0].GetComponent<AudioSource>();
        Intro_Sounds[0].loop = false;

        Intro_subtitle[1] = Canvas.transform.GetChild(1).gameObject;
        Intro_subtitle[2] = Canvas.transform.GetChild(2).gameObject;
        Intro_subtitle[3] = Canvas.transform.GetChild(3).gameObject;

        Scenes[0] = transform.GetChild(0).gameObject;
        Scenes[1] = transform.GetChild(1).gameObject;
        Scenes[2] = transform.GetChild(2).gameObject;
        Scenes[3] = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //최초의 Fade, GameStart를 지우기 위함
    void Fade()
    {
        if(IsItFade)
            FadeSystem.GetComponent<Fade>().DoFade(2f);
        else
            FadeSystem.GetComponent<Fade>().StopFade(2f);
        
        IsItFade = !IsItFade;
    }
    void StartScene()
    {
        Scenes[index].SetActive(true);

    }
    void StartTitle()
    { 
        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Intro_subtitle[index].SetActive(true);
        //Intro_Sounds[index].Play();
    }

    void EndScene()
    {
        Scenes[index].SetActive(false);
        index += 1;
    }

    void EndTitle()
    {
        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Intro_subtitle[index].SetActive(false);
    }

    void StartGame()
    {
        Stage1.SetActive(true);
        mail.SetActive(true);
        Fade();
        gameObject.SetActive(false);
    }

    public void LetsStart()
    {
        //Fade -> 2초 대기 후 Fade 해제 반복

        //first
        Invoke("Fade", 0.1f);
        Invoke("StartScene", 3f);
        Invoke("Fade", 3f);
        Invoke("StartTitle", 5f);
        Invoke("EndTitle", 10f);
        Invoke("EndScene", 12f);

        //Second
        Invoke("Fade", 10f);
        Invoke("StartScene", 12f);
        Invoke("Fade", 12f);
        Invoke("StartTitle", 14f);
        Invoke("EndTitle", 19f);
        Invoke("EndScene", 21f);

        //Third
        Invoke("Fade", 19f);
        Invoke("StartScene", 21f);
        Invoke("Fade", 21f);
        Invoke("StartTitle", 23f);
        Invoke("EndTitle", 28f);
        Invoke("EndScene", 30f);

        Invoke("Fade",28f);

        //Fourth
        Invoke("StartScene", 30f);
        Invoke("Fade", 30f);
        Invoke("StartTitle", 32f);
        Invoke("EndTitle", 37f);
        Invoke("Fade", 37f);
        Invoke("EndScene", 39f);

        Invoke("StartGame", 39f);


    }
}
