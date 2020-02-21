using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshSurface))]
public class NavmeshBaker : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;

    [SerializeField] private List<GameObject> platformObjects;

    // Start is called before the first frame update
    void Start()
    {
        GameObject o = GameObject.FindObjectsOfType<NavMeshSurface>()
        
        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }

    public void UpdateNavigationMesh()
    {
        surface.BuildNavMesh();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            surface.BuildNavMesh();
        }
    }
}