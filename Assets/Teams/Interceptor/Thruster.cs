using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Interceptor
{
	[TaskCategory("Interceptor")]
	public class Thruster : Action
	{

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Vitesse")]
		public float vitesse;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("ShipThruster")]
		public SharedFloat shipThruster;

		public override void OnStart()
		{
		}

		public override TaskStatus OnUpdate()
		{
			shipThruster.SetValue(vitesse);
			return TaskStatus.Success;
		}

		
	}
}