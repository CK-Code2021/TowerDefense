using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ns
{
    ///<summary>
    ///游戏管理
    ///<summary>
	public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;
        public GameObject endUI;
        public Text endText;                        //结束显示游戏胜利或失败

        private EnemySpawner enemySpawner;

        private void Start()
        {
            gameManager = this;
            enemySpawner = GetComponent<EnemySpawner>();
        }

        public void Win()
        {
            endUI.SetActive(true);
            endText.text = "游 戏 胜 利";
            endText.color = Color.green;
        }

        public void Failed()
        {
            enemySpawner.Stop();
            endUI.SetActive(true);
            endText.text = "游 戏 失 败";
            endText.color = Color.red;
        }

        public void OnButtonAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnButtonMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }        
    }
}

