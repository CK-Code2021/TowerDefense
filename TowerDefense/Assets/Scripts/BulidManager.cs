using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ns
{
    ///<summary>
    ///建造炮塔
    ///<summary>	
    public class BulidManager : MonoBehaviour
    {       
        public TurretData LaserTurret;
        public TurretData MissileTurret;
        public TurretData StandardTurret;
        public int money = 1000;
        public Text moneyText;
        public Animator moneyAnimator;

        private MapCube selectedMapCub;             //记录上次选择的方块
        private TurretData selectedTurretData;      //当前选择的炮台       

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
                if(EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("WhiteMapCube"));

                    if (isCollider)
                    {
                        MapCube mapCube = hit.collider.GetComponent<MapCube>();                        
                        
                        if(selectedTurretData != null && mapCube.turretGo == null)
                        {
                            if (money >= selectedTurretData.cost)
                            {
                                mapCube.BuildTurret(selectedTurretData);
                                ChangeMoney(-selectedTurretData.cost);                             
                            }
                            else
                                moneyAnimator.SetTrigger("Flicker");
                        }
                        else if(mapCube.turretGo != null)                   //炮塔升级处理
                        {                            
                            if (mapCube == selectedMapCub && TurretUpgradeUI.upgradeCanvas.gameObject.activeInHierarchy)
                                StartCoroutine(TurretUpgradeUI.HideUpgradeUI());
                            else
                                TurretUpgradeUI.ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgradeTurrret);

                            selectedMapCub = mapCube;
                        }
                    }
                }
        }

        private void ChangeMoney(int change)
        {
            money += change;
            moneyText.text = "现有金币￥" + money;
        }

        public void OnUpgradeButtonDown()
        {
            if (money >= selectedMapCub.currentTurretData.costUpgraded)
            {
                ChangeMoney(-selectedMapCub.currentTurretData.costUpgraded);
                selectedMapCub.UpgradeTurret();
            }               
            else
                moneyAnimator.SetTrigger("Flicker");

            StartCoroutine(TurretUpgradeUI.HideUpgradeUI());
        }

        public void OnDestroyButtonDown()
        {
            selectedMapCub.DestroyTurret();
            StartCoroutine(TurretUpgradeUI.HideUpgradeUI());
        }

        public void OnLaserSelected(bool isOn)
        {
             if (isOn)
                selectedTurretData = LaserTurret;
        }

        public void OnMissileSelected(bool isOn)
        {
            if (isOn)
                selectedTurretData = MissileTurret;
        }

        public void OnStandardSelected(bool isOn)
        {
            if (isOn)
                selectedTurretData = StandardTurret;
        }
    }
}

