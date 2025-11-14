using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [Header("Componentes")]
    public NavMeshAgent agent;          // Controlador de movimiento
    public Transform player;            // Referencia al jugador

    [Header("Patrullaje")]
    public Transform[] waypoints;       // Puntos de patrulla
    public float patrolSpeed = 2f;      // Velocidad cuando patrulla
    private int currentWaypointIndex = 0;

    [Header("Persecución")]
    public float chaseSpeed = 5f;       // Velocidad al perseguir
    public float detectionRadius = 10f; // Distancia para detectar jugador
    public float loseSightRadius = 15f; // Distancia para dejar de perseguir

    private AIState currentState;       // Estado actual de la IA

    void Start()
    {
        // Inicializar referencias
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        // Estado inicial: patrullar
        currentState = new PatrolState();
        currentState.OnEnter(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    // Transición de un estado a otro
    public void TransitionToState(AIState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }

    // Métodos auxiliares para los estados
    public bool CanSeePlayer()
    {
        if (player == null) return false;
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= detectionRadius;
    }

    public bool LostPlayer()
    {
        if (player == null) return true;
        float distance = Vector3.Distance(transform.position, player.position);
        return distance > loseSightRadius;
    }

    public void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;
        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
