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
            Vector2 shootAngle = myShip.Value - target.Value;
            float orientationRadiant = Mathf.Deg2Rad * orientation.Value;
            Vector2 orientationShip = new Vector2(Mathf.Cos(orientationRadiant), Mathf.Sin(orientationRadiant));
            int layerMask = 1 << 10;
            RaycastHit2D hit = Physics2D.Raycast(myShip.Value + orientationShip.normalized, orientationShip, DistanceFromEnemy.Value, layerMask);
            Debug.DrawRay(myShip.Value + orientationShip.normalized, orientationShip);
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
