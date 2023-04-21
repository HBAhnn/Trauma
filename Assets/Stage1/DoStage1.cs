using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoStage1 : MonoBehaviour
{
    public static bool Stage1_Controll = true;

    GameObject Intro;
    AudioSource Intro_sound;

    public GameObject Scroll;

    // Start is called before the first frame update
    void Start()
    {
        Intro = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        Intro_sound = gameObject.GetComponent<AudioSource>();
        StartCoroutine(Start_Text());
    }

    IEnumerator Start_Text()
    {
        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Intro.SetActive(true);
        Intro_sound.Play();
        yield return new WaitForSeconds(6.5f);

        GameObject.Find("Subtitle_bar").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Intro.SetActive(false);
        Stage1_Controll = false;
        Scroll.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
