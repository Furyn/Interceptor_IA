using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class CheckAsteroid : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Target Pos")]
        public SharedVector2 target;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Ship pos")]
        public SharedVector2 myShip;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("myship orientation")]
        public SharedFloat myShipOrientation;

        /*[BehaviorDesigner.Runtime.Tasks.Tooltip("Asteroid in between")]
        public SharedBool asteroidInBetween;*/

        public override TaskStatus OnUpdate()
        {
            float shootAngle = Mathf.Deg2Rad * myShipOrientation.Value;

            RaycastHit2D hit = Physics2D.Raycast(myShip.Value, new Vector2(Mathf.Cos(shootAngle), Mathf.Sin(shootAngle)));

            if (hit.collider.CompareTag("Asteroid"))
            {
                //asteroidInBetween.SetValue(true);
                return TaskStatus.Failure;
            }
            else
            {
                return TaskStatus.Success;
            }

            
        }
    }
}
