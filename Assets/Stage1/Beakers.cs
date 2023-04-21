using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beakers : MonoBehaviour
{
    Transform Parent, Beakerss;
    // Start is called before the first frame update

    AudioSource open_icon;
    void Start()
    {
        Parent = transform.parent;
        Beakerss = Parent.GetChild(1);
        open_icon = GameObject.Find("Open_Menu").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        open_icon.Play();
        Beakerss.gameObject.SetActive(true);
    }
}
