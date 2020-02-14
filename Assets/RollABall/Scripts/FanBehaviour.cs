using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehaviour : MonoBehaviour //is in a scene, think of it like an object
{
    public float fanSpeed = 10f; //float (or other like int) -> tells what it is; Name of it has to be first variable little letter and next are Capitalised

    private void OnTriggerStay(Collider other) //void - what method gives back; () To decet when it is in there; like a collider but doesnt stop movement
    {
        if (other.GetComponent<Rigidbody>() != null) { //checking Object for rigid body to not throw error
            other.GetComponent<Rigidbody>().AddForce(transform.forward);

        } 
    }

}
