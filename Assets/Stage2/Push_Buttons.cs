using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Push_Buttons : MonoBehaviour
{
    bool wrong_event = false;

    //R, Y, B, G
    Transform[] Buttons = new Transform[9];

    Transform[] Passwords = new Transform[3];
    SpriteRenderer[] Render = new SpriteRenderer[3];

    public Sprite[] numbers;

    Transform Password;
    int[] password_num = new int[3];
    int password_index;

    AudioSource Error_Sounds;

    GameObject subtitle;

    GameObject BGM;

    AudioSource Clear_Lock;

    AudioSource Smog_sound;

    public GameObject smogSystem;
    public GameObject FadeSystem;

    public GameObject Stage3;

    public GameObject mail;
    /*


    AudioSource Clear_Windy;
    */


    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("First_bgm");
        Smog_sound = GameObject.Find("Windy_sound").GetComponent<AudioSource>();

        subtitle = GameObject.Find("Canvas_Elevator").transform.GetChild(3).gameObject;

        Password = transform.GetChild(9);
        for (int i = 0; i < 9; i++)
            Buttons[i] = transform.GetChild(i);
        for (int i = 0; i < 3; i++)
            Passwords[i] = Password.GetChild(i);
        for (int i = 0; i < 3; i++)
            Render[i] = Passwords[i].GetComponent<SpriteRenderer>();

        password_index = 0;

        Error_Sounds = gameObject.GetComponent<AudioSource>();

        Clear_Lock = GameObject.Find("Stage2_LockSound").GetComponent<AudioSource>();
        /*
        ClearPassword();
        Clear_Windy = GameObject.Find("Stage1_SmokeSound").GetComponent<AudioSource>();
        */
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        if(wrong_event)
            StartCoroutine(Wrong());
    }

    IEnumerator ClearStage()
    {
        DoStage2.Stage2_Controll = true;
        Clear_Lock.Play();
        yield return new WaitForSeconds(1);

        //Close Button Images
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < 3; i++)
            Passwords[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;

        //Get subtitle
        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        subtitle.SetActive(true);
        yield return new WaitForSeconds(3);

        //Get smokes
        smogSystem.GetComponent<Fade>().DoFade(3.5f);
        Smog_sound.Play();
        //Clear_Windy.Play();

        yield return new WaitForSeconds(4.2f);

        //Do fade, end Subtitle
        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        subtitle.SetActive(false);
        FadeSystem.GetComponent<Fade>().DoFade(2f);

        
        //Change Stage
        BGM.SetActive(false);

        yield return new WaitForSeconds(2f);
        smogSystem.GetComponent<Fade>().StopFade(0.1f);
        Stage3.SetActive(true);

        //Stop fade
        yield return new WaitForSeconds(0.1f);
        subtitle.SetActive(false);
        FadeSystem.GetComponent<Fade>().StopFade(2f);
        mail.SetActive(false);
        DoStage3.Stage3_Controll = false;
        transform.parent.transform.parent.gameObject.SetActive(false);
        
    }

    IEnumerator Wrong()
    {
        wrong_event = true;
        Error_Sounds.Play();
        yield return new WaitForSeconds(1);
        Render[0].sprite = null;
        Render[1].sprite = null;
        Render[2].sprite = null;
        password_index = 0;
        wrong_event = false;
    }

    public void InputPassword(int num)
    {
        //Wrong Sound가 출력 중에는 함수 진행 X
        if (wrong_event) return;
        if (password_index == 3) return;

        password_num[password_index] = num;
        Render[password_index].sprite = numbers[num];
        Passwords[password_index].gameObject.SetActive(true);

        password_index++;

        if (password_index == 3)
        {
            if (password_num[0] == 0 && password_num[1] == 0 && password_num[2] == 8)
            {
                StartCoroutine(ClearStage());
            }
            else
            {
                StartCoroutine(Wrong());
            }
        }
    }
    
}
