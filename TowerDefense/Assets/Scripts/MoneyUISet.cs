using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ns
{
    ///<summary>
    ///UI金额设置
    ///<summary>
	public class MoneyUISet : MonoBehaviour
    {
        public GameObject batteryCheck;

        private GameObject moneyText1;
        private GameObject moneyText2;
        private GameObject moneyText3;

        void Start()
        {
            moneyText1 = batteryCheck.transform.Find("LaserToggle/Money1").gameObject;
            moneyText1.GetComponent<Text>().text = "￥" + GetComponent<BulidManager>().LaserTurret.cost;
            moneyText2 = batteryCheck.transform.Find("MissileToggle/Money2").gameObject;
            moneyText2.GetComponent<Text>().text = "￥" + GetComponent<BulidManager>().MissileTurret.cost;
            moneyText3 = batteryCheck.transform.Find("StandardToggle/Money3").gameObject;
            moneyText3.GetComponent<Text>().text = "￥" + GetComponent<BulidManager>().StandardTurret.cost;
        }             
    }
}

