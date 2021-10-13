using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class CheckDistanceFromEnemy : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Enemy Pos")]
        public SharedVector2 enemy;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Ship pos")]
        public SharedVector2 myShip;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Distance from enemy")]
        public SharedFloat distance;

        public override TaskStatus OnUpdate()
        {
            
            distance.SetValue(Vector2.Distance(enemy.Value, myShip.Value));
            return TaskStatus.Success;
        }



    }
}
