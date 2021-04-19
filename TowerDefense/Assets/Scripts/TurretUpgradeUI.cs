using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ns
{
    ///<summary>
    ///炮塔升级UI
    ///<summary>
	public class TurretUpgradeUI : MonoBehaviour
    {     
        public static Transform upgradeCanvas;
        
        private static Button upgradeButton;
        private static Animator buttonUIAnimator;

        private void Start()
        {
            upgradeCanvas = transform.Find("UpgradeCanvas");
            upgradeButton = upgradeCanvas.Find("UpgradeButton").GetComponent<Button>();
            buttonUIAnimator = upgradeCanvas.GetComponent<Animator>();
        }

        public static void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
        {
            upgradeCanvas.gameObject.SetActive(false);      
            upgradeCanvas.gameObject.SetActive(true);
            upgradeCanvas.transform.position = pos;
            upgradeButton.interactable = !isDisableUpgrade;
        }

        public static IEnumerator HideUpgradeUI()
        {
            IEnumerator HideUI()
            {
                buttonUIAnimator.SetTrigger("Hide");
                yield return new WaitForSeconds(0.5f);
                upgradeCanvas.gameObject.SetActive(false);
            }

            return HideUI();
        }               
    }
}

