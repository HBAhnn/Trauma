using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBoard : MonoBehaviour
{
    Transform Parent, board;
    AudioSource open_icon;
    // Start is called before the first frame update
    void Start()
    {
        Parent = transform.parent;
        board = Parent.GetChild(1);
        open_icon = GameObject.Find("Open_Menu").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (DoStage2.Stage2_Controll == false)
        {
            open_icon.Play();
            board.gameObject.SetActive(true);
        }
    }
}
