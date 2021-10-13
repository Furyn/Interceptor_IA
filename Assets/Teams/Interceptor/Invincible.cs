using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class Invincible : Action
    {
        public SharedBool isInvincible;

        public override TaskStatus OnUpdate()
        {
            if (isInvincible.Value)
                return TaskStatus.Success;
            return TaskStatus.Failure;
        }
    }
}