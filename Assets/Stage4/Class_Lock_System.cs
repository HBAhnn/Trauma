using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Lock_System : MonoBehaviour
{
    //wrong_event 호출 중에는 락 system 건드리지 못하게
    bool wrong_event = false;

    //R, Y, B, G
    Transform[] Buttons = new Transform[10];

    Transform[] Passwords = new Transform[2];
    SpriteRenderer[] Render = new SpriteRenderer[2];

    Transform Password;
    int[] password_num = new int[2];
    int password_index;

    AudioSource Error_Sounds;
    AudioSource Clear_Lock;
    AudioSource Clear_Windy;

    GameObject subtitle;
    GameObject subtitle2;

    public GameObject smogSystem;
    public GameObject FadeSystem;

    public GameObject ending;

    public GameObject key;

    public GameObject mail;

    public GameObject Toclose;
    public GameObject Toclose1;
    public GameObject Toclose2;

    public GameObject Light_door;

    // Start is called before the first frame update
    void Start()
    {
        subtitle = GameObject.Find("Canvas_class").transform.GetChild(0).gameObject;
        subtitle2 = GameObject.Find("Canvas_class").transform.GetChild(1).gameObject;

        Password = transform.GetChild(10);
        for (int i = 0; i < 10; i++)
            Buttons[i] = transform.GetChild(i);
        for (int i = 0; i < 2; i++)
            Passwords[i] = Password.GetChild(i);
        for (int i = 0; i < 2; i++)
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
        Clear_Lock.Play();

        Toclose.SetActive(false);
        Toclose1.SetActive(false);
        Toclose2.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //render deactive + narration start
        for (int i = 0; i <= 10; i++)
            transform.GetChild(10).gameObject.SetActive(false);
        key.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        subtitle.SetActive(true);

        yield return new WaitForSeconds(3f);

        subtitle.SetActive(false);
        subtitle2.SetActive(true);
        yield return new WaitForSeconds(5f);

        subtitle2.SetActive(false);
        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);


        FadeSystem.GetComponent<Fade>().DoFade(2f);
        yield return new WaitForSeconds(2f);


        Light_door.SetActive(true);
        FadeSystem.GetComponent<Fade>().StopFade(1f);
        yield return new WaitForSeconds(4f);


        FadeSystem.GetComponent<Fade>().DoFade(2f);
        yield return new WaitForSeconds(2f);

        ending.SetActive(true);
        transform.parent.transform.parent.gameObject.SetActive(false);
        /*

        //Do fade
        FadeSystem.GetComponent<Fade>().DoFade(2f);

        //Change Stage
        yield return new WaitForSeconds(2f);
        smogSystem.GetComponent<Fade>().StopFade(0.1f);
        Stage2.SetActive(true);

        //Stop fade
        yield return new WaitForSeconds(0.1f);
        FadeSystem.GetComponent<Fade>().StopFade(2f);
        mail.SetActive(false);
        DoStage1.Stage1_Controll = false;
        transform.parent.transform.parent.gameObject.SetActive(false);
        */
    }

    IEnumerator Wrong()
    {
        wrong_event = true;

        Error_Sounds.Play();
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 2; i++)
            Passwords[i].gameObject.SetActive(false);

        password_index = 0;

        wrong_event = false;

    }

    public void InputPassword(int num)
    {
        if (wrong_event)
            return;
        if (password_index == 2) return;

        password_num[password_index] = num;
        Passwords[password_index].gameObject.SetActive(true);

        password_index++;

        if (password_index == 2)
        {
            if (password_num[0] == 1 && password_num[1] == 7)
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
