using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Lock_Password_System Parent;
    int m_IndexNumber;
    // Start is called before the first frame update
    void Start()
    {
        m_IndexNumber = transform.GetSiblingIndex();
        Parent = transform.GetComponentInParent<Lock_Password_System>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Parent.InputPassword(m_IndexNumber);
    }
}
