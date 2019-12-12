using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    /// <summary>
    /// This class tells the boss which attack to do
    /// </summary>
    public class BossStateAttack : BossState
    {

        int pickAnAttack; // Holds which attack to do
        bool isAttacking = false; // tells if the boss is attacking or not
        int currentAttack = 0; // holds the current attack that was picked

        /// <summary>
        /// Overrides the start function of the of the bossStateMachine, this function chooses an attack to do at random
        /// </summary>
        /// <param name="boss">Holds a copy of the bossStateMachine in the boss param</param>
        public override void OnStart(BossStateMachine boss)
        {

            pickAnAttack = Random.Range(1, 5);
            AttackList();
            ///pickAnAttack = 1;

        }
        /// <summary>
        /// Overrides the update function of the of the bossStateMachine, this function swaps to an attack to do
        /// </summary>
        /// <param name="boss">Holds a copy of the bossStateMachine in the boss param</param>
        public override BossState Update(BossStateMachine boss)
        {
            

            if (currentAttack == 1 && isAttacking == true)
            {

                Debug.Log("ATTACK01");
                
            }
            if (currentAttack == 2 && isAttacking == true)
            {

                Debug.Log("ATTACK02");
            }
            

            return null;
        }
        /// <summary>
        /// Overrides the end function of the of the bossStateMachine, this also resets everything back to the way it was
        /// </summary>
        /// <param name="boss">Holds a copy of the bossStateMachine in the boss param</param>
        public override void OnEnd(BossStateMachine boss)
        {
            pickAnAttack = 0;
            currentAttack = 0;
            isAttacking = false;

        }

        /// <summary>
        /// This function holds a list of attacks that the boss can swap to
        /// </summary>
        public void AttackList()
        {
            if (pickAnAttack == 1)
            {
                currentAttack = 1;
                isAttacking = true;
                Debug.Log("01");
            }
            if (pickAnAttack == 2)
            {
                currentAttack = 2;
                isAttacking = true;
                Debug.Log("02");
            }
            if (pickAnAttack == 3)
            {
                currentAttack = 3;
                isAttacking = true;
                Debug.Log("03");
            }
            if (pickAnAttack == 4)
            {
                currentAttack = 4;
                isAttacking = true;
                Debug.Log("04");
            }
        }
    }
}