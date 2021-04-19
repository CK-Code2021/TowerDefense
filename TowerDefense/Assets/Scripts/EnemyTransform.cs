using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ns
{
    ///<summary>
    ///敌人移动
    ///<summary>
	public class EnemyTransform : MonoBehaviour
    {
        public GameObject explosionEffect;       
        public float speed = 10;
        public float hp = 100;       

        private Slider hpSlider;                    //敌人血条
        private Transform[] position;               //路点位置
        private int index = 0;
        private float toolHp;

        void Start()
        {
            position = WayPoint.position;
            toolHp = hp;
            hpSlider = GetComponentInChildren<Slider>();
        }
       
        void Update()
        {
            Move();
        }

        private void Move()
        {
            if (index > position.Length - 1)
                return;

            transform.Translate((position[index].position - transform.position).normalized * Time.deltaTime * speed);

            if(Vector3.Distance(position[index].position, transform.position) < 0.5f)
                index++;

            if (index > position.Length - 1)
                ReachDestroy();
        }

        //到达终点
        private void ReachDestroy()
        {
            GameManager.gameManager.Failed();
            GameObject.Destroy(gameObject);
        }

        private void OnDestroy()
        {
            EnemySpawner.enemyLiveNumber--;
        }

        public void TakeDamage(float damage)
        {
            hp -= damage;
            hpSlider.value = (float)hp / toolHp;            //血条

            if (hp <= 0)
                Die();
        }

        private void Die()
        {
            GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(effect, 1.5f);
            Destroy(gameObject);
        }
    }
}

