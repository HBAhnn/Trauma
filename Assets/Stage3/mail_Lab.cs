using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mail_Lab : MonoBehaviour
{
    bool Over = false, Click = false;
    Transform mail_open, mail_close, mail_paper;

    // Start is called before the first frame update
    void Start()
    {
        mail_open = transform.GetChild(0);
        mail_close = transform.GetChild(1);
        mail_paper = transform.GetChild(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Over || Click)
        {
            mail_open.gameObject.SetActive(true);
            mail_close.gameObject.SetActive(false);
            if (Click)
            {
                mail_paper.gameObject.SetActive(true);
                Click = false;
            }
        }
        else
        {
            mail_open.gameObject.SetActive(false);
            mail_close.gameObject.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        if (DoStage3.Stage3_Controll == false)
            Over = true;
    }
    private void OnMouseExit()
    {
        if (DoStage3.Stage3_Controll == false)
            Over = false;
    }

    private void OnMouseDown()
    {
        if (DoStage3.Stage3_Controll == false)
            Click = true;
    }
}
