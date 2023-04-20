using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLock : MonoBehaviour
{
    Transform Parent, BigLock;

    // Start is called before the first frame update
    void Start()
    {
        Parent = transform.parent;
        BigLock = Parent.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (DoStage1.Stage1_Controll == false)
            BigLock.gameObject.SetActive(true);
    }
}
