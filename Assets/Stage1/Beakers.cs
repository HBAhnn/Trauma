using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beakers : MonoBehaviour
{
    Transform Parent, Beakerss;
    // Start is called before the first frame update
    void Start()
    {
        Parent = transform.parent;
        Beakerss = Parent.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Beakerss.gameObject.SetActive(true);
    }
}
