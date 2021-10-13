using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using DoNotModify;

//test dov

namespace Interceptor {

	public class ExampleController : BaseSpaceShipController
	{
        public BehaviorTree behaviorTree;
        public override void Initialize(SpaceShipView spaceship, GameData data)
		{
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
		{
			SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			float thrust = 1.0f;
			bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);

			behaviorTree.SetVariableValue("EnnemyShipPos", otherSpaceship.Position);

			SharedFloat angleDir = (SharedFloat)behaviorTree.GetVariable("Direction");
			Debug.Log(angleDir.Value);
			float targetOrient = spaceship.Orientation + angleDir.Value;

			return new InputData(thrust, targetOrient, needShoot, false, false);
		}
	}

}
