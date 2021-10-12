using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using DoNotModify;

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
			float targetOrient = spaceship.Orientation + 90.0f;
			bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);
            SharedBool shoot = (SharedBool)behaviorTree.GetVariable("Shoot");
            SharedBool mine = (SharedBool)behaviorTree.GetVariable("MineDropped");
            SharedBool shock = (SharedBool)behaviorTree.GetVariable("UseChock");
            return new InputData(thrust, targetOrient, shoot.Value, mine.Value, shock.Value);
		}
	}
}
