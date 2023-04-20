using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ele : MonoBehaviour
{
    Push_Buttons Parent;
    int m_IndexNumber;
    // Start is called before the first frame update
    void Start()
    {
        m_IndexNumber = transform.GetSiblingIndex();
        Parent = transform.GetComponentInParent<Push_Buttons>();
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
