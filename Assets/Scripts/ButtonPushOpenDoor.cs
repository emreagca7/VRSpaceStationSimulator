using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    public Animator animator;
    public string boolName = "Open";

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToogleDoorOpen());
    }

    public void ToogleDoorOpen()
    {
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);

        AudioManager.instance.Play("Door");
    }
}
