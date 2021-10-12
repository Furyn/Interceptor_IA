using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;
using UnityEngine;

namespace Interceptor
{
    [TaskCategory("Unity")]
    [TaskIcon("Assets/Behavior Designer Tutorials/Tasks/Editor/{SkinColor}SeekIcon.png")]
    public class Mine : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Target Pos")]
        public SharedBool mine;
        [BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;

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
            mine = true;
            return TaskStatus.Success;
        }

        public override void OnEnd()
        {
            mine = false;
        }

    }
}