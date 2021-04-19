using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ns
{
    ///<summary>
    ///按钮控制
    ///<summary>
	public class ButtonControl : MonoBehaviour
    {
        public void OnButtonStart()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OnButtonExit()
        {
#if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

