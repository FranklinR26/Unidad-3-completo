using UnityEngine;

public class ChaseState : AIState
{
    public override void OnEnter(AIController controller)
    {
        controller.agent.speed = controller.chaseSpeed;
    }

    public override void UpdateState(AIController controller)
    {
        if (controller.player == null) return;

        // Actualiza el destino hacia el jugador
        controller.agent.SetDestination(controller.player.position);

        // Si pierde de vista al jugador, volver a patrullar
        if (controller.LostPlayer())
        {
            controller.TransitionToState(new PatrolState());
        }
    }

    public override void OnExit(AIController controller)
    {
        // Nada especial al salir
    }
}
