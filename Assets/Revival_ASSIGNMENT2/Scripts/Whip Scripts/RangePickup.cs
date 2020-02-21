using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))] //whatever the game object must have a collider
public class RangePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //anytime smth interacts with this, it will be fired
    {
        if (other.GetComponent<PlayerController>() != null) //looking for the player component and see if it exists
        {
            Destroy(gameObject);
        }
    }
}
