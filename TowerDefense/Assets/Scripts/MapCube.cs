using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ns
{
    ///<summary>
    ///地图方块
    ///<summary>
	public class MapCube : MonoBehaviour
    {
        [HideInInspector]
        public GameObject turretGo;       
        [HideInInspector]
        public bool isUpgradeTurrret = false;
        [HideInInspector]
        public GameObject buildEffect;
        public TurretData currentTurretData;                //保存炮塔的数据

        private Renderer renderer;    

        private void Start()
        {
            renderer = GetComponent<Renderer>();         
        }

        public void BuildTurret(TurretData turretData)
        {
            currentTurretData = turretData;
            turretGo = GameObject.Instantiate(turretData.turretPrefeb, transform.position, Quaternion.identity);
            GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1);
        }

        public void UpgradeTurret()
        {
            if (isUpgradeTurrret == true)
                return;
            else
            {
                Vector3 targetPosition = turretGo.GetComponent<TurretAttack>().targetPosition;
                Destroy(turretGo);
                turretGo = GameObject.Instantiate(currentTurretData.turretUpgradePrefab, transform.position, transform.rotation);
                turretGo.GetComponent<TurretAttack>().head.LookAt(targetPosition);
                GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1);
                isUpgradeTurrret = true;
            }
        }

        public void DestroyTurret()
        {
            Destroy(turretGo);
            GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1);
            isUpgradeTurrret = false;
            turretGo = null;
            currentTurretData = null;
        }

        private void OnMouseEnter()
        {
            if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false)
                renderer.material.color = Color.red;
        }

        private void OnMouseExit()
        {
            renderer.material.color = Color.white;
        }
    }
}

