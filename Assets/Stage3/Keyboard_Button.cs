using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard_Button : MonoBehaviour
{
    Key_Board Parent;
    int m_IndexNumber;
    AudioSource Notes;
    // Start is called before the first frame update
    void Start()
    {
        m_IndexNumber = transform.GetSiblingIndex();
        Parent = transform.GetComponentInParent<Key_Board>();
        Notes = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Notes.Play();
        Parent.InputPassword(m_IndexNumber);
    }
}
