using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class CheckEnnemy : Conditional
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Target Pos")]
        public SharedVector2 target;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Orientation")]
        public SharedFloat orientation;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Ship pos")]
        public SharedVector2 myShip;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Distance From Enemy")]
        public SharedFloat DistanceFromEnemy;

        public override TaskStatus OnUpdate()
        {
            Vector2 shootAngle = target.Value - myShip.Value;
            float deltaAngle = Vector2.SignedAngle(target.Value, myShip.Value);
            int layerMask = 1 << 10;
            RaycastHit2D hit = Physics2D.Raycast(myShip.Value + shootAngle, shootAngle, orientation.Value, layerMask);
            //RaycastHit2D hit = Physics2D.BoxCast(myShip.Value + shootAngle, new Vector2(1, 1), deltaAngle, shootAngle, DistanceFromEnemy.Value, layerMask);
            if (hit)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return TaskStatus.Success;
                }
            }
            return TaskStatus.Failure;

        }
    }
}
