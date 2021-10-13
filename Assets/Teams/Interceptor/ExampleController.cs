using BehaviorDesigner.Runtime;
using DoNotModify;
using UnityEngine;

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
			float thrust = (float)behaviorTree.GetVariable("ShipThruster").GetValue();

			if (data.Mines.Count > 0)
            {
				SharedVector2 posMineProche = data.Mines[0].Position;
				Vector2 distanceMineProche = data.Mines[0].Position - spaceship.Position;

				foreach (MineView new_mine in data.Mines)
				{
                    if (!new_mine.IsActive)
                    {
						continue;
                    }
					Vector2 distanceMine = new_mine.Position - spaceship.Position;
					if ( Mathf.Abs(distanceMine.x) + Mathf.Abs(distanceMine.y) < Mathf.Abs(distanceMineProche.x) + Mathf.Abs(distanceMineProche.y))
					{
						distanceMineProche = distanceMine;
						posMineProche = new_mine.Position;
					}
				}
				behaviorTree.SetVariableValue("MinePos", posMineProche);
			}
            else
            {
				behaviorTree.SetVariableValue("MinePos", Vector2.negativeInfinity);
			}

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
