using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class CheckAsteroid : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Asteroid in between")]
        public SharedBool asteroidInBetween;

        //public RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        public override TaskStatus OnUpdate()
        {

            return TaskStatus.Success;
        }
    }
}
