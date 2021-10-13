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

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Ship pos")]
		public SharedVector2 myShip;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Ship Orientation")]
		public SharedFloat myShipOrientation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Angle dir")]
		public SharedFloat angleDir;

		public override void OnStart()
		{
		}

		public override TaskStatus OnUpdate()
		{

			float shootAngle = Mathf.Deg2Rad * myShipOrientation.Value;
			Vector2 shootDirection = new Vector2(Mathf.Cos(shootAngle), Mathf.Sin(shootAngle));
			Vector2 spaceshipToTarget = target.Value - myShip.Value;

			angleDir.SetValue(Vector2.SignedAngle(shootDirection, spaceshipToTarget));

			Debug.Log(angleDir);
			return TaskStatus.Success;
		}

		
	}
}