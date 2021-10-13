using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;
using UnityEngine;

namespace Interceptor
{
	[TaskCategory("Interceptor")]
	public class TargetPoint : Action
	{

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Target Pos")]
		public SharedVector2 target;
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject myShip;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Target Pos")]
		public SharedFloat angleDir;

		public override void OnStart()
		{
		}

		public override TaskStatus OnUpdate()
		{

			Vector2 dir = myShip.Value.transform.position - new Vector3(target.Value.x, target.Value.y, target.Value.y);
			dir = myShip.Value.transform.InverseTransformDirection(dir);
			angleDir = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Debug.Log(angleDir);
			return TaskStatus.Success;
		}

		
	}
}