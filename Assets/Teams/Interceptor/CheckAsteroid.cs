using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class CheckAsteroid : Conditional
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Target Pos")]
        public SharedVector2 target;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Ship pos")]
        public SharedVector2 myShip;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Distance From Enemy")]
        public SharedFloat DistanceFromEnemy;

        public override TaskStatus OnUpdate()
        {
            Vector2 shootAngle = target.Value - myShip.Value;
            int layerMask = 1 << 12;
            RaycastHit2D hit = Physics2D.Raycast(myShip.Value, shootAngle, DistanceFromEnemy.Value, layerMask);
            if (hit)
            {
                if (hit.collider.CompareTag("Asteroid"))
                {
                    return TaskStatus.Failure;
                }
            }
            return TaskStatus.Success;

        }
    }
}
