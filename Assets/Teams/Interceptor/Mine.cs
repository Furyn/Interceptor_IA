using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class Mine : Action
    {
        public SharedBool isDropped;

        public override void OnStart()
        {
            isDropped.SetValue(true);
        }
    }
}