using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///敌人生成器
    ///<summary>
	public class EnemySpawner : MonoBehaviour
    {
        public static int enemyLiveNumber = 0;              //当前存活的敌人
        public Enemy[] enemys;
        public Transform start;
        public float enemyRate = 1;                         //每波敌人的延迟时间

        private void Start()
        {
            StartCoroutine("SpawnerEnemy");
        }

        public void Stop()
        {
            StopCoroutine("SpawnerEnemy");
        }

        IEnumerator SpawnerEnemy()
        {
            foreach (Enemy enemy in enemys)
            {
                for (int i = 0; i < enemy.number; i++)
                {
                    GameObject.Instantiate(enemy.enemyPrefab, start.position, Quaternion.identity);
                    enemyLiveNumber++;

                    if (i != enemy.number - 1)
                        yield return new WaitForSeconds(enemy.rate);
                }

                while (enemyLiveNumber != 0)
                {
                    yield return new WaitForSeconds(enemyRate);
                }               
            }

            /* if(enemyLiveNumber == 0)
                 GameManager.gameManager.Win();*/

            while (enemyLiveNumber > 0)
            {
                yield return 0;
            }

            GameManager.gameManager.Win();
        }       
    }
}

