using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Board : MonoBehaviour
{
    bool wrong_event = false;

    //R, Y, B, G
    Transform[] Buttons = new Transform[7];

    Transform[] Passwords = new Transform[7];
    SpriteRenderer[] Render = new SpriteRenderer[7];

    public Sprite[] numbers;

    Transform Password;
    int[] password_num = new int[7];
    int password_index;

    AudioSource Error_Sounds;
    AudioSource Clear_Lock;
    AudioSource Clear_Windy;

    GameObject subtitle;

    public GameObject smogSystem;
    public GameObject FadeSystem;

    public GameObject Stage4;

    public GameObject mail;

    public GameObject Toclose1;
    public GameObject Toclose2;



    // Start is called before the first frame update
    void Start()
    {
        subtitle = GameObject.Find("Canvas_study").transform.GetChild(0).gameObject;

        Password = transform.GetChild(7);
        for (int i = 0; i < 7; i++)
            Buttons[i] = transform.GetChild(i);
        for (int i = 0; i < 7; i++)
            Passwords[i] = Password.GetChild(i);
        for (int i = 0; i < 7; i++)
            Render[i] = Passwords[i].GetComponent<SpriteRenderer>();

        password_index = 0;

        Error_Sounds = GameObject.Find("Wrong_number_sound").GetComponent<AudioSource>();
        Clear_Lock = GameObject.Find("Correct_number_open").GetComponent<AudioSource>();
        Clear_Windy = GameObject.Find("Windy_sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        if (wrong_event)
            StartCoroutine(Wrong());
    }

    IEnumerator ClearStage()
    {
        DoStage3.Stage3_Controll = true;
        Clear_Lock.Play();
        Toclose1.GetComponent<BoxCollider2D>().enabled = false;
        Toclose2.GetComponent<BoxCollider2D>().enabled = false;

        //Close Button Images
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < 7; i++)
            Passwords[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < 7; i++)
            Buttons[i].gameObject.SetActive(false);
        Password.gameObject.SetActive(false);

        transform.parent.GetChild(0).gameObject.SetActive(false);

        mail.SetActive(false);
        yield return new WaitForSeconds(1);


        //Get subtitle

        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        subtitle.SetActive(true);
        //TODO : 여기서 나레이션 재생
        yield return new WaitForSeconds(4);

        //Get smokes
        smogSystem.GetComponent<Fade>().DoFade(3.5f);
        Clear_Windy.Play();

        yield return new WaitForSeconds(4.2f);

        //Do fade

        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        subtitle.SetActive(false);
        FadeSystem.GetComponent<Fade>().DoFade(2f);


        //Change Stage
        yield return new WaitForSeconds(2f);
        smogSystem.GetComponent<Fade>().StopFade(0.1f);
        Stage4.SetActive(true);

        //Stop fade
        yield return new WaitForSeconds(0.1f);
        FadeSystem.GetComponent<Fade>().StopFade(2f);
        //mail.SetActive(false);
        DoStage3.Stage3_Controll = false;
        transform.parent.transform.parent.transform.parent.gameObject.SetActive(false);
        
    }

    IEnumerator Wrong()
    {
        wrong_event = true;
        Error_Sounds.Play();
        yield return new WaitForSeconds(1);
        for(int i = 0; i < 7; i++)
            Passwords[i].gameObject.SetActive(false);
        password_index = 0;
        wrong_event = false;
    }

    public void InputPassword(int num)
    {
        //Wrong Sound가 출력 중에는 함수 진행 X
        if (wrong_event) return;
        if (password_index == 7) return;

        password_num[password_index] = num;
        Passwords[password_index].gameObject.SetActive(true);

        password_index++;

        if (password_index == 7)
        {
            if (password_num[0] == 0 && password_num[1] == 0 && password_num[2] == 4 && password_num[3] == 4
                && password_num[4] == 5 && password_num[5] == 5 && password_num[6] == 4)
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
