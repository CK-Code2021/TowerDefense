using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///炮塔攻击
    ///<summary>
	public class TurretAttack : MonoBehaviour
    {
        public List<GameObject> enemys = new List<GameObject>();        //存放进入攻击范围的敌人
        public LineRenderer laserRenderer;
        public GameObject bulletPrefab;
        public Transform firePoint;
        public Vector3 targetPosition;
        public Transform head;       
        public float laserDamageRate = 80;
        public float attackRateTime = 1;                    
        public bool isLaser = false;

        private float timer = 0;

        private void Start()
        {
            timer = attackRateTime;
        }

        private void Update()
        {           
            if (enemys.Count > 0 && enemys[0] != null)
            {
                targetPosition = enemys[0].transform.position;
                targetPosition.y = head.position.y;
                head.LookAt(targetPosition);
            }

            if (isLaser == false)
            {
                timer += Time.deltaTime;

                if (enemys.Count > 0  && timer >= attackRateTime)
                {
                    timer = 0;
                    Attack();
                }
            }
            else if (enemys.Count > 0)
            {
                if (laserRenderer.enabled == false)
                    laserRenderer.enabled = true;

                if (enemys[0] == null)
                    UpdateEnemy();

                if (enemys.Count > 0)
                {
                    laserRenderer.SetPositions(new Vector3[] { firePoint.position, enemys[0].transform.position });
                    enemys[0].GetComponent<EnemyTransform>().TakeDamage(laserDamageRate * Time.deltaTime);
                }                   
            }
            else
                laserRenderer.enabled = false;
        }

        private void Attack()
        {
            if (enemys[0] == null)
                UpdateEnemy();

            if (enemys.Count > 0)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
            }
            else
                timer = attackRateTime;
        }

        private void UpdateEnemy()
        {
            enemys.RemoveAll(item => item == null);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
                enemys.Add(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Enemy")
                enemys.Remove(other.gameObject);
        }       
    }
}

