using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoStage4 : MonoBehaviour
{
    public static bool Stage4_Controll = false;
    public GameObject mail;

    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("Third_bgm").GetComponent<AudioSource>();
        BGM.Play();

        mail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
