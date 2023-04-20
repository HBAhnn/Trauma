using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        transform.gameObject.SetActive(false);
    }
}
