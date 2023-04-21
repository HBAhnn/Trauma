using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    bool rotation = false;
    public GameObject background;

    public GameObject Beaker;
    public GameObject Lock;

    AudioSource move_sound;

    void Start()
    {

        move_sound = GameObject.Find("Move_Background").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (DoStage1.Stage1_Controll == false)
        {
            move_sound.Play();
            background.transform.position = new Vector3(background.transform.position.x * -1, background.transform.position.y, background.transform.position.z);
            if (!rotation)
            {
                transform.position = new Vector3(-8, 0, 0);
                transform.localEulerAngles = new Vector3(0, 180, 0);
                Beaker.SetActive(true);
                Lock.SetActive(false);
            }
            else
            {
                transform.position = new Vector3(8, 0, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                Beaker.SetActive(false);
                Lock.SetActive(true);
            }
            rotation = !rotation;
        }
    }
}
