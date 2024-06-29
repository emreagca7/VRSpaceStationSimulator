using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;
    private bool wasOn;
    public float forwardSpeed;
    public float sideSpeed;
   
    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        Vector3 velocity = new Vector3(-forwardVelocity, 0, sideVelocity);
        transform.position += velocity * Time.deltaTime;

        if (lever.value != wasOn)
        {
            if (lever.value)
            {
                AudioManager.instance.Play("Engine");
            }
            else
            {
                AudioManager.instance.Stop("Engine");
            }
        }

        wasOn = lever.value;
    }
}
