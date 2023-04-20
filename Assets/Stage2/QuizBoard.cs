using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBoard : MonoBehaviour
{
    Transform Parent, board;
    // Start is called before the first frame update
    void Start()
    {
        Parent = transform.parent;
        board = Parent.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (DoStage2.Stage2_Controll == false)
            board.gameObject.SetActive(true);
    }
}
