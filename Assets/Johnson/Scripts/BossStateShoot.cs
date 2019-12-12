using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    /// <summary>
    /// This class holds the shooting state for the boss
    /// </summary>
    public class BossStateShoot : BossState
    {

        float timeBetweenShots = .5f; // this holds the time that the boss has to wait before firing again
        float timeUntilNextShot = 2; // this hold the time until the next shot

        /// <summary>
        /// This function overrides the bossstate update function, this function decides whether the boss shoots or not
        /// </summary>
        /// <param name="boss"></param>
        /// <returns></returns>
        public override BossState Update(BossStateMachine boss)
        {
            Debug.Log("Pew Pew");

            timeUntilNextShot -= Time.deltaTime;

            if(timeUntilNextShot <= 0)
            {
                boss.ShootProjectile();
                timeUntilNextShot = timeBetweenShots;
            }
           
            //boss.ShootProjectile();

            if (!boss.CanSeeAttackTarget())
            {
                return new BossStateIdle();
            }
            else if (boss.DistanceToAttackTargt() < boss.attackDistanceThreshold)
            {
                return new BossStateAttack();
            }
            else
            {
                return null;
            }
            
        }

        
    }
}