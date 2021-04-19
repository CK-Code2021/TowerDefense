using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///炮台数据
    ///<summary>
    [System.Serializable]
    public class TurretData
    {
        public GameObject turretPrefeb;
        public int cost;
        public GameObject turretUpgradePrefab;
        public int costUpgraded;
        public TurretType type;
    }

    public enum TurretType
    {
        LaserTurret,
        MissileTurret,
        StandardTurret
    }
}

