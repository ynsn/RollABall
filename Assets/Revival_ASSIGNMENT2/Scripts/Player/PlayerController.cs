using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private string platformTag = "Platform";
    [SerializeField] private Camera playerCamera;

    [SerializeField] private int whipReach = 1;
    [SerializeField] private float speed = 1.0f;

    private NavMeshAgent agent;

    public delegate void PlayerMove(Vector3 source, Vector3 target);

    public event PlayerMove OnPlayerMove;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.GetComponent<NavMeshSurface>())
                {
                    Debug.Log("Moving player...");
                    OnPlayerMove(transform.position, hit.point);
                    agent.destination = hit.point;
                }
            }
        }
    }
}