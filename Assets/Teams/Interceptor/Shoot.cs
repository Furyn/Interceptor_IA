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
        private GameObject prevGameObject;
        private SpaceShip spaceShip;

        public override void OnStart()
        {
            GameObject currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject)
            {
                spaceShip = currentGameObject.GetComponent<SpaceShip>();
                prevGameObject = currentGameObject;
            }
            
        }

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


