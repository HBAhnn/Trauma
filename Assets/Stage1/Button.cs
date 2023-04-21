using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Lock_Password_System Parent;
    int m_IndexNumber;

    AudioSource click_password;
    // Start is called before the first frame update
    void Start()
    {
        m_IndexNumber = transform.GetSiblingIndex();
        Parent = transform.GetComponentInParent<Lock_Password_System>();
        click_password = GameObject.Find("Click_Password").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        click_password.Play();
        Parent.InputPassword(m_IndexNumber);
    }
}
