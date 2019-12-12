using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {

        /// <summary>
        /// these variables are read only for other classes
        /// </summary>
        protected GameObject owner;
        protected Rigidbody body;

        /// <summary>
        /// how fast the projectile moves through the scene
        /// </summary>
        float speed = 10;
        /// <summary>
        /// How long the bullet can live for.
        /// </summary>
        float lifetime = 2;

        /// <summary>
        /// how many seconds this projectile has been alive
        /// </summary>
        float age = 0;

        /// <summary>
        /// Gets the Rigid body on the object and stores it in the variable called Owner
        /// </summary>
        void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// this function shoots a projectile out of whatever called towards its target
        /// </summary>
        /// <param name="owner">Holds a copy of the the game object to pass into the function</param>
        /// <param name="direction">holds the direction for the projectile to travel</param>
        public void Shoot(GameObject owner, Vector3 direction)
        {
            this.owner = owner;
            body = GetComponent<Rigidbody>();
            body.velocity = direction * speed;
        }

      

        // Update is called once per frame
        void Update()
        {
            GetOlderAndDie();
        }

        /// <summary>
        /// this function takes increases the age of a projectile and when it hits a certain age it gets destroyed
        /// </summary>
        protected void GetOlderAndDie()
        {
            age += Time.deltaTime;

            if (age >= lifetime)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// This function tells if the projectile hits something
        /// </summary>
        /// <param name="other">This param holds the collider of any object that the projectile hits</param>
        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject == owner) return; // don't hit the shooter of this projectile!

            print("hit");
            Destroy(gameObject);
        }
    }
}
