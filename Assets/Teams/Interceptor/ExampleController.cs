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

            float distanceFromEnemy = Vector2.Distance(otherSpaceship.Position, spaceship.Position);
            behaviorTree.SetVariableValue("DistanceFromEnemy", distanceFromEnemy);

            #region Check Bullet

            if (data.Bullets.Count > 0)
            {
                int layerMask = 1 << 10;
                bool bulletCanHitMe = false;
                foreach (BulletView bullet in data.Bullets)
                {
                    if (Vector2.Distance(spaceship.Position, bullet.Position) > 1)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(bullet.Position, bullet.Velocity, Mathf.Infinity, layerMask);
                        
                        if(hit)
                        {
                            bulletCanHitMe = true;
                        }
                        else
                        {
                            behaviorTree.SetVariableValue("BulletCanHitMe", false);
                        }
                    }
                    Debug.Log(data.Bullets.Count);
                    
                    /*if (Vector2.Dot(spaceship.Velocity.normalized, bullet.Velocity.normalized) >= 1f)
                        behaviorTree.SetVariableValue("BulletCanHitMe", true);
                    else
                        behaviorTree.SetVariableValue("BulletCanHitMe", false);*/
                }

                behaviorTree.SetVariableValue("BulletCanHitMe", bulletCanHitMe);
            }
            else
            {
                behaviorTree.SetVariableValue("BulletCanHitMe", false);
            }

            #endregion

            #region Calcul WayPoint
            SharedVector2 posWaypointProche = data.WayPoints[0].Position;
            Vector2 distanceWaypointProche = data.WayPoints[0].Position - spaceship.Position;
            float distanceLimit = 0.2f;

            foreach (WayPointView wayPoint in data.WayPoints)
            {
                Vector2 distanceWayPoint = wayPoint.Position - spaceship.Position;
                if (Mathf.Abs(distanceWayPoint.x) + Mathf.Abs(distanceWayPoint.y) < Mathf.Abs(distanceWaypointProche.x) + Mathf.Abs(distanceWaypointProche.y))
                {
                    if (wayPoint.Owner != spaceship.Owner)
                    {
                        distanceWaypointProche = distanceWayPoint;
                        posWaypointProche = wayPoint.Position;
                    }
                }
            }
            if (Mathf.Abs(distanceWaypointProche.x) + Mathf.Abs(distanceWaypointProche.y) < distanceLimit)
                behaviorTree.SetVariableValue("OnWayPoint", true);
            else
                behaviorTree.SetVariableValue("OnWayPoint", false);

            behaviorTree.SetVariableValue("WaypointPos", posWaypointProche);
            #endregion

            #region Calcul Mine
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
            #endregion

            #region Check Invincibility

            if (otherSpaceship.HitCountdown > 0f)
                behaviorTree.SetVariableValue("IsInvincible", true);
            else
                behaviorTree.SetVariableValue("IsInvincible", false);

            #endregion

            int nbrWaypoint = (int)Mathf.Ceil((data.WayPoints.Count / 2)) + 1;

            behaviorTree.SetVariableValue("OurScore", spaceship.Score);
            behaviorTree.SetVariableValue("NumberOfWayPoint", nbrWaypoint);
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
