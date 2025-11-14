using UnityEngine;

public class PatrolState : AIState
{
    public override void OnEnter(AIController controller)
    {
        controller.agent.speed = controller.patrolSpeed;
        controller.GoToNextWaypoint();
    }

    public override void UpdateState(AIController controller)
    {
        // Si detecta al jugador, cambia a persecución
        if (controller.CanSeePlayer())
        {
            controller.TransitionToState(new ChaseState());
            return;
        }

        // Si llegó al waypoint, ir al siguiente
        if (!controller.agent.pathPending && controller.agent.remainingDistance < 0.5f)
        {
            controller.GoToNextWaypoint();
        }
    }

    public override void OnExit(AIController controller)
    {
        // Nada especial al salir
    }
}
