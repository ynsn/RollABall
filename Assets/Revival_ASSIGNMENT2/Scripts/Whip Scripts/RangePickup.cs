using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))] //whatever the game object must have a collider
public class RangePickup : MonoBehaviour
{
    [SerializeField] private float increaseValueBy = 1f;

    private void OnTriggerEnter(Collider other) //anytime smth interacts with this, it will be fired
    {
        if (other.GetComponent<WhipBehavior>() != null) //looking for the player component and see if it exists
        {
            other.GetComponent<WhipBehavior>().IncreaseRange(increaseValueBy);
            Destroy(gameObject);
        }
    }
}
