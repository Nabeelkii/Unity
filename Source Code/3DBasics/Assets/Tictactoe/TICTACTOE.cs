using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TICTACTOE : MonoBehaviour
{
    public bool player1 = true;
    [SerializeField] Text msg0=null;
    [SerializeField] Text msg1=null;
    [SerializeField] Text msg2=null;
    [SerializeField] Text msg3=null;
    [SerializeField] Text msg4=null;
    [SerializeField] Text msg5=null;
    [SerializeField] Text msg6=null;
    [SerializeField] Text msg7=null;
    [SerializeField] Text msg8=null;
    [SerializeField] Text msg9=null;
    [SerializeField] GameObject B1 = null;
    [SerializeField] GameObject B2 = null;
    [SerializeField] GameObject B3 = null;
    [SerializeField] GameObject B4 = null;
    [SerializeField] GameObject B5 = null;
    [SerializeField] GameObject B6 = null;
    [SerializeField] GameObject B7 = null;
    [SerializeField] GameObject B8 = null;
    [SerializeField] GameObject B9 = null;


    public void Button1()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg1.text = "X";  }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg1.text = "O"; }
        B1.GetComponent<Button>().interactable = false;
    }
    public void Button2()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg2.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg2.text = "O"; }
        B2.GetComponent<Button>().interactable = false;
    }
    public void Button3()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg3.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg3.text = "O"; }
        B3.GetComponent<Button>().interactable = false;
    }
    public void Button4()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg4.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg4.text = "O"; }
        B4.GetComponent<Button>().interactable = false;
    }
    public void Button5()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg5.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg5.text = "O"; }
        B5.GetComponent<Button>().interactable = false;
    }
    public void Button6()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg6.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg6.text = "O"; }
        B6.GetComponent<Button>().interactable = false;
    }
    public void Button7()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg7.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg7.text = "O"; }
        B7.GetComponent<Button>().interactable = false;
    }
    public void Button8()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg8.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg8.text = "O"; }
        B8.GetComponent<Button>().interactable = false;
    }
    public void Button9()
    {
        if (player1) { msg0.text = "Player 2 Turn"; player1 = false; msg9.text = "X"; }
        else if (!player1) { msg0.text = "Player 1 Turn"; player1 = true; msg9.text = "O"; }
        B9.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        if
        (
           //check horizontal
            (msg1.text==msg2.text && msg2.text==msg3.text && msg1.text == "X") || 
            (msg4.text ==msg5.text && msg5.text == msg6.text && msg4.text == "X") || 
            (msg7.text == msg8.text && msg8.text == msg9.text && msg7.text == "X") ||
            //check vertical
            (msg1.text == msg4.text && msg4.text == msg7.text && msg1.text == "X") ||
            (msg2.text == msg5.text && msg5.text == msg8.text && msg2.text == "X") ||
            (msg3.text == msg6.text && msg6.text == msg9.text && msg3.text == "X") ||
            //check crossed
            (msg1.text == msg5.text && msg5.text == msg9.text && msg1.text == "X") ||
            (msg3.text == msg5.text && msg5.text == msg7.text && msg3.text == "X") 
        )
        {
            msg0.text = "Player 1 wins";
            Disablebuttons();
        }
        else if
       (
           //check horizontal
           (msg1.text == msg2.text && msg2.text == msg3.text && msg1.text == "O") ||
           (msg4.text == msg5.text && msg5.text == msg6.text && msg4.text == "O") ||
           (msg7.text == msg8.text && msg8.text == msg9.text && msg7.text == "O") ||
           //check vertical
           (msg1.text == msg4.text && msg4.text == msg7.text && msg1.text == "O") ||
           (msg2.text == msg5.text && msg5.text == msg8.text && msg2.text == "O") ||
           (msg3.text == msg6.text && msg6.text == msg9.text && msg3.text == "O") ||
           //check crossed
           (msg1.text == msg5.text && msg5.text == msg9.text && msg1.text == "O") ||
           (msg3.text == msg5.text && msg5.text == msg7.text && msg3.text == "O")
       )
        {
            msg0.text = "Player 2 wins";
            Disablebuttons();
        }
        else if (GameEnd())
        {
            msg0.text = "Draw";
        }
        

    }

    private void Disablebuttons()
    {
        B1.GetComponent<Button>().interactable = false;
        B2.GetComponent<Button>().interactable = false;
        B3.GetComponent<Button>().interactable = false;
        B4.GetComponent<Button>().interactable = false;
        B5.GetComponent<Button>().interactable = false;
        B6.GetComponent<Button>().interactable = false;
        B7.GetComponent<Button>().interactable = false;
        B8.GetComponent<Button>().interactable = false;
        B9.GetComponent<Button>().interactable = false;
    }

    private bool GameEnd()
    {
      if
        (B1.GetComponent<Button>().interactable == false &&
        B2.GetComponent<Button>().interactable == false &&
        B3.GetComponent<Button>().interactable == false &&
        B4.GetComponent<Button>().interactable == false &&
        B5.GetComponent<Button>().interactable == false &&
        B6.GetComponent<Button>().interactable == false &&
        B7.GetComponent<Button>().interactable == false &&
        B8.GetComponent<Button>().interactable == false &&
        B9.GetComponent<Button>().interactable == false
       )
        {
            return true;
        }
      else
        {
            return false;
        }
    }


}
