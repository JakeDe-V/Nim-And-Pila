using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostScript : MonoBehaviour
{
    [SerializeField] private Transform firstTarget;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(firstTarget.position);
    }
}
