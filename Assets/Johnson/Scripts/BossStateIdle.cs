using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This namespace keeps everything in it seperate from other scripts
/// </summary>
namespace Johnson
{
    /// <summary>
    /// This is the idle state for the boss
    /// </summary>
    public class BossStateIdle : BossState
    {

        
        int shootOrPursueDecider; // decides whether to shoot or pursue
        
        /// <summary>
        ///  this overrides the bossState update function
        /// </summary>
        /// <param name="boss">Stores a copy of the bossStateMachine class in the boss param</param>
        /// <returns>returns what state to switch to</returns>
        public override BossState Update(BossStateMachine boss)
        {

            //do stuff to the boss...

            Debug.Log("idle");

            // transitions to other states


            
            if (boss.DistanceToAttackTargt() < boss.visionDistanceThreshold) // if Distance to attack target is less than the vision distance threshold then...
            {
                
                return new BossStatePursue(); // swap to pursue class
                                             
            }
            


            return null; // stay in current state
            
            
        }
        
        
    }
}