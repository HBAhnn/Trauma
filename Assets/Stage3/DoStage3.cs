using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoStage3 : MonoBehaviour
{
    public static bool Stage3_Controll = false;
    public GameObject mail;

    // Start is called before the first frame update
    void Start()
    {
        mail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
