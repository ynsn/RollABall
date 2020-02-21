using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshBaker : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> platformObjects;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshSurface[] o = FindObjectsOfType<NavMeshSurface>();
        Debug.Log(o.Length);
        
        foreach (NavMeshSurface obj in o)
        {
            platformObjects.Add(obj);
        }
    }

    public void UpdateNavigationMesh()
    {
        foreach (NavMeshSurface platformObject in platformObjects)
        {
            platformObject.BuildNavMesh();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            UpdateNavigationMesh();
        }
    }
}