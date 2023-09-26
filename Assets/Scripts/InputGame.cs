using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputGame : MonoBehaviour
{
    [SerializeField] JoystickInput joystickInput;
  
    public void ShowCursorState(bool state)
    {
        if (joystickInput.isJoystickMobile())
            return;
        Cursor.visible = state;
        if (!state)
            Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;

    }

}


