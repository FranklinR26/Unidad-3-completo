public abstract class AIState
{
    public abstract void OnEnter(AIController controller);
    public abstract void UpdateState(AIController controller);
    public abstract void OnExit(AIController controller);
}
