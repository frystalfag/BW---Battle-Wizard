using UnityEngine;
using UnityEngine.AI;
public class SkeletController : MonoBehaviour
{
    public StateMachine stateMachine;
    public Animator animator;
    public NavMeshAgent Agent;
    public Transform Player;

    void Start()
    {
        stateMachine = new StateMachine();
        animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
