using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebackground3 : MonoBehaviour
{
    // Start is called before the first frame update
    bool rotation = false;
    public GameObject background;

    public GameObject Orgel;
    public GameObject Piano;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (DoStage3.Stage3_Controll == false)
        {
            background.transform.position = new Vector3(background.transform.position.x * -1, background.transform.position.y, background.transform.position.z);
            if (!rotation)
            {
                transform.position = new Vector3(-8, 0, 0);
                transform.localEulerAngles = new Vector3(0, 180, 0);
                Orgel.SetActive(true);
                Piano.SetActive(false);
            }
            else
            {
                transform.position = new Vector3(8, 0, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                Orgel.SetActive(false);
                Piano.SetActive(true);
            }
            rotation = !rotation;
        }
    }
}
