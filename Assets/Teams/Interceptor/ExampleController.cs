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
			behaviorTree.SetVariableValue("ShipPos", spaceship.Position);
			behaviorTree.SetVariableValue("ShipOrientaion", spaceship.Orientation);

			float angleDir = ((SharedFloat)behaviorTree.GetVariable("Direction")).Value;

			float targetOrient = spaceship.Orientation + angleDir;

			bool shock = (bool)behaviorTree.GetVariable("UseChock").GetValue();
			bool mine = (bool)behaviorTree.GetVariable("MineDropped").GetValue();
			bool shoot = (bool)behaviorTree.GetVariable("Shoot").GetValue();

			behaviorTree.SetVariableValue("Shoot", false);
			behaviorTree.SetVariableValue("UseChock", false);
			behaviorTree.SetVariableValue("MineDropped", false);

			return new InputData(thrust, targetOrient, shoot, mine, shock);
		}
	}

}
