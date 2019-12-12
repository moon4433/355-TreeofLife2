using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class ProjectileHomimg : Projectile
    {
        /// <summary>
        /// holds the tranform info for the target
        /// </summary>
        Transform target;
        /// <summary>
        /// Force for the homing missel
        /// </summary>
        float homingForce = 10000;
        /// <summary>
        /// max force for the projectile
        /// </summary>
        float maxForce = 1000;

        /// <summary>
        /// This is the shooting function for the homing class
        /// </summary>
        /// <param name="owner">holds a copy of the object that the script is on</param>
        /// <param name="target">holds the transform info of the target</param>
        /// <param name="direction">holds the vector info of the direction towards the target</param>
        public void Shoot(GameObject owner, Transform target, Vector3 direction)
        {
            this.target = target;
            Shoot(owner, direction);

        }
        /// <summary>
        /// This function updates for the current frame
        /// </summary>
        private void Update()
        {
            GetOlderAndDie();
            Homing();

            
        }
        /// <summary>
        /// This function holds all the homing info for the prjectile
        /// </summary>
        private void Homing()
        {
            Vector3 dir = (target.position - transform.position).normalized; // direction
            Vector3 steer = dir * homingForce - body.velocity; // the steering for the homing missel
            steer = steer.normalized * maxForce; // adds force the normalized steering and puts it back into the steering
            body.AddForce(steer * Time.deltaTime); // adds the steering to the body by adding the force
        }
    }
}