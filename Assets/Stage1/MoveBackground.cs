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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (DoStage1.Stage1_Controll == false)
        {
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
