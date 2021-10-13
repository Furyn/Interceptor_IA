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

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Need to shoot")]
        public SharedBool shoot;

        public override void OnStart()
        {
            shoot.SetValue(true);
        }



    }
}
