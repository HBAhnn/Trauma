using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStart : MonoBehaviour
{
    StartScenario start;
    bool clicked = true;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.GetComponentInParent<StartScenario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (clicked)
        {
            start.LetsStart();
            clicked= false;
        }
    }
}
