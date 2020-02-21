using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateBehaviour : MonoBehaviour
{
    public bool IsTriggered = false;
    public UnityEvent Activated;
    private void OnCollisionEnter()
    {
        IsTriggered = true;
        Activated.Invoke();
    }

    private void OnCollisionExit()
    {
        IsTriggered = false;
    }
}
