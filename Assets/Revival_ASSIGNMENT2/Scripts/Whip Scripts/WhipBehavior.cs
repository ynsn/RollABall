using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipBehavior : MonoBehaviour
{
    private NavmeshBaker navBaker = null;

    [SerializeField] private float range = 5f;

    private void Start()
    {
        navBaker = FindObjectOfType<NavmeshBaker>();
        navBaker.UpdateNavigationMesh();
    }

    public void CheckIfInRange(Vector3 source, Vector3 target)
    {

    }

    /// <summary> Increases range of this whip. </summary>
    /// <param name="value"> Value to increase range by. </param>
    public void IncreaseRange(float value)
    {
        range += value;
    }
}
