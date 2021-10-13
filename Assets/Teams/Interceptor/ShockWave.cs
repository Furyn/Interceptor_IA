using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class ShockWave : Action
    {
        public SharedBool useShock;

        public override void OnStart()
        {
            useShock.SetValue(true);
        }
    }
}
