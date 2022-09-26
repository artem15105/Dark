using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDice : MonoBehaviour
{
    public Controller controller;

    public void startMotion()
    {
        controller.controllerDrive.motion = true;

    }
}
