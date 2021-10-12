using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class Mine : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("isDropped")]
        public SharedBool isDropped;

        public override TaskStatus OnUpdate()
        {
            isDropped = true;
            return TaskStatus.Success;
        }

        public override void OnEnd()
        {
            isDropped = false;
        }
    }
}