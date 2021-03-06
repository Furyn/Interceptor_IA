using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DoNotModify;

namespace Interceptor
{
    [TaskCategory("Interceptor")]
    public class Shoot : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Need to shoot")]
        public SharedBool shoot;

        public override void OnStart()
        {
            shoot.SetValue(true);
        }
    }
}


