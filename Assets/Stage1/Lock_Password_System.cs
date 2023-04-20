using UnityEngine;
using System.Collections;

public class Lock_Password_System : MonoBehaviour
{
    //wrong_event 호출 중에는 락 system 건드리지 못하게
    bool wrong_event = false;

    //R, Y, B, G
    Transform[] Buttons = new Transform[10];
    
    Transform[] Passwords = new Transform[4];
    SpriteRenderer[] Render = new SpriteRenderer[4];

    Transform Password;
    int[] password_num = new int[4];
    int password_index;

    public GameObject FadeSystem;
    public GameObject smogSystem;
    public GameObject Stage2;

    public GameObject mail;
    
    AudioSource Error_Sounds;
    AudioSource Clear_Windy;
    AudioSource Clear_Lock;


    // Start is called before the first frame update
    void Start()
    {
        Password = transform.GetChild(10);
        for (int i = 0; i < 10; i++)
            Buttons[i] = transform.GetChild(i);
        for (int i = 0; i < 4; i++)
            Passwords[i] = Password.GetChild(i);
        for (int i = 0; i < 4; i++)
            Render[i] = Passwords[i].GetComponent<SpriteRenderer>();

        ClearPassword();
        password_index = 0;

        Error_Sounds = gameObject.GetComponent<AudioSource>();
        Clear_Windy = GameObject.Find("Stage1_SmokeSound").GetComponent<AudioSource>();
        Clear_Lock = GameObject.Find("Stage1_LockSound").GetComponent<AudioSource>();
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

    private void ClearPassword()
    {
        for(int i = 0; i<4; i++)
        {
            Passwords[i].gameObject.SetActive(false);
        }
    }

    private void Color_Red()
    {
        for (int i = 0; i < 4; i++)
        {
            Render[i].color = new Color(1,0,0,1);
        }
    }
    private void Color_Green()
    {
        for (int i = 0; i < 4; i++)
        {
            Render[i].color = new Color(1, 1, 1, 1);
        }
    }

    IEnumerator ClearStage()
    {
        DoStage1.Stage1_Controll = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < 4; i++)
            Passwords[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Quiz1").GetComponent<SpriteRenderer>().enabled = false;
        Clear_Lock.Play();
        yield return new WaitForSeconds(1);

        //Get smokes
        smogSystem.GetComponent<Fade>().DoFade(3.5f);
        Clear_Windy.Play();
        
        yield return new WaitForSeconds(4.2f);
        
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
    }

    IEnumerator Wrong()
    {
        wrong_event = true;

        Error_Sounds.Play();
        Color_Red();
        yield return new WaitForSeconds(1f);

        Color_Green();
        yield return new WaitForSeconds(1f);

        Color_Red();
        yield return new WaitForSeconds(1f);

        ClearPassword();
        password_index = 0;
        Color_Green();

        wrong_event = false;
    }

    public void InputPassword(int num)
    {
        if (wrong_event)
            return;
        password_num[password_index] = num;
        Passwords[password_index].gameObject.SetActive(true);

        password_index++;

        if (password_index == 4)
        {
            if (password_num[0] == 1 && password_num[1] == 1 && password_num[2] == 0
                && password_num[3] == 0)
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
