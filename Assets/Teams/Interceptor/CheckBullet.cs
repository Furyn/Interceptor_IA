using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class CheckBullet : Action
    {
        public SharedBool bulletCanHitMe;

        public override TaskStatus OnUpdate()
        {
            if (bulletCanHitMe.Value)
                return TaskStatus.Success;
            return TaskStatus.Failure;
        }
    }
}
