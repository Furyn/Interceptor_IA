using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
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
		public SharedVector2 myShipVelocity;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Angle dir")]
		public SharedFloat angleDir;

		public override void OnStart()
		{
		}

		public override TaskStatus OnUpdate()
		{

			float deltaAngle =  Vector2.SignedAngle(myShipVelocity.Value, target.Value - myShip.Value);
			deltaAngle *= 1.8f;
			deltaAngle = Mathf.Clamp(deltaAngle, -170, 170);
			float velocityOrientation = Vector2.SignedAngle(Vector2.right, myShipVelocity.Value);
			float finalOrientation = velocityOrientation + deltaAngle;

			angleDir.SetValue(finalOrientation);

			return TaskStatus.Success;
		}

		
	}
}