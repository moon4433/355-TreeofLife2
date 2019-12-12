using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    /// <summary>
    /// The bosses state machine
    /// </summary>
    public class BossStateMachine : MonoBehaviour
    {
        public float visionDistanceThreshold = 10f;
        public float pursueDistanceThreshold = 7;
        public float attackDistanceThreshold = 5;
        public float speed = 10f;

        public Projectile prefabProjectile;
        public ProjectileHomimg prefabProjectileHoming;

        [HideInInspector]
        public Vector3 velocity = new Vector3();

        BossState currentState;

        public Transform attackTarget { get; private set; }

        // constructor function
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) attackTarget = player.transform; 
        }

        // update function, updates boss every frame
        void Update()
        {
            if (currentState == null) SwitchToState(new BossStateIdle());

            if (currentState != null) SwitchToState(currentState.Update(this));
            
        }
        /// <summary>
        /// This function handles the swaping of classes for the boss
        /// </summary>
        /// <param name="newState">Gets a new copy of the BossState and makes it the current state</param>
        private void SwitchToState(BossState newState)
        {
            if (newState != null)
            {
                if(currentState != null) currentState.OnEnd(this);
                currentState = newState;
                currentState.OnStart(this);
            }
        }
        /// <summary>
        /// Gets the vector to the attack target
        /// </summary>
        /// <returns>vector 3</returns>
        public Vector3 VectorToAttackTarget()
        {
            return attackTarget.position - transform.position;
        }

        /// <summary>
        /// Gets distance to attack target
        /// </summary>
        /// <returns>float</returns>
        public float DistanceToAttackTargt()
        {

            return VectorToAttackTarget().magnitude;
        }

        /// <summary>
        /// This function tells if the boss can see the target or not
        /// </summary>
        /// <returns>Boolean</returns>
        public bool CanSeeAttackTarget()
        {
            if (attackTarget == null) return false;
            Vector3 vectorBetween = VectorToAttackTarget();

            if (vectorBetween.sqrMagnitude < visionDistanceThreshold * visionDistanceThreshold)
            {
                // player is close enough to boss to activate it...
                Ray ray = new Ray(transform.position, vectorBetween.normalized);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform == attackTarget) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// this function tells the boss to shoot a prjectile
        /// </summary>
        public void ShootProjectile()
        {
            Projectile newProjectile =Instantiate(prefabProjectile, transform.position, Quaternion.identity);

            Vector3 dir = VectorToAttackTarget().normalized;

            newProjectile.Shoot(gameObject, dir);
        }

        /// <summary>
        ///  this fucntion tells the boss to shoot homing projectile or not
        /// </summary>
        public void ShootHomingProjectile()
        {
            ProjectileHomimg newProjectile = Instantiate(prefabProjectileHoming, transform.position, Quaternion.identity);

            newProjectile.Shoot(gameObject, attackTarget, Vector3.up);
        }
    }
}