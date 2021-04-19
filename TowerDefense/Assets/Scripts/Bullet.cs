using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///子弹
    ///<summary>
	public class Bullet : MonoBehaviour
    {
        public GameObject explosionEffectPrefab;
        public int damage = 50;
        public float speed = 50;
        
        private Transform target;

        public void SetTarget(Transform target1)
        {
            this.target = target1;
        }
       
        void Update()
        {
            if (target == null)
            {
                Die();
                return;
            }

            transform.LookAt(target.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);                 
        }

        private void OnTriggerEnter(Collider other)
        {           
            if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyTransform>().TakeDamage(damage);
                Die();
            }              
        }

        private void Die()
        {
            GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(gameObject);
        }
    }
}

