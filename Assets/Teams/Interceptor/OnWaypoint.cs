using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class OnWaypoint : Action
    {
        public SharedBool onWayPoint;

        public override TaskStatus OnUpdate()
        {
            if(onWayPoint.Value)
                return TaskStatus.Success;
            return TaskStatus.Failure;
        }

    }
}
