using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoStage2 : MonoBehaviour
{
    public static bool Stage2_Controll = true;

    public GameObject mail;

    GameObject Intro;
    GameObject[] Subtitles = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        Intro = GameObject.Find("Canvas_Elevator");
        for(int i = 0; i < 3; i++)
        {
            Subtitles[i] = Intro.transform.GetChild(i).gameObject;
        }
        StartCoroutine(Start_Text());
        mail.SetActive(true);
    }
    IEnumerator Start_Text()
    {
        //fade now....
        yield return new WaitForSeconds(2f);

        Stage2_Controll = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
