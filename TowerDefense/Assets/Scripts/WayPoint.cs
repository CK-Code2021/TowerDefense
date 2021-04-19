using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///路点
    ///<summary>
	public class WayPoint : MonoBehaviour
    {
        public static Transform[] position;
 
        void Start()
        {
            position = new Transform[transform.childCount];

            for (int i = 0; i < position.Length; i++)
            {
                position[i] = transform.GetChild(i);
            }
        }      
    }
}

