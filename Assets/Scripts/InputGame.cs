using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputGame : MonoBehaviour
{

    public void ShowCursorState(bool state)
    {
        Cursor.visible = state;
        if (!state)
            Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;

    }

}


