using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class ShockWave : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("isDropped")]
        public SharedBool useShock;

        public override TaskStatus OnUpdate()
        {
            useShock = true;
            return TaskStatus.Success;
        }

        public override void OnEnd()
        {
            useShock = false;
        }
    }
}
