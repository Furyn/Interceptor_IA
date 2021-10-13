using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class Shoot : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Spaceship")]
        public SharedGameObject targetGameObject;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Need to shoot")]
        public SharedBool shoot;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Need to shoot")]
        public SharedFloat distanceFromEnemy;

        public float shootingMaxDistance;

        public override TaskStatus OnUpdate()
        {
            if(distanceFromEnemy.Value < shootingMaxDistance)
            {
                shoot = true;
            }
            {

            }

            return base.OnUpdate();
        }


    }
}


