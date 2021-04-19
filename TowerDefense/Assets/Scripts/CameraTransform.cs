using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///像机移动
    ///<summary>
	public class CameraTransform : MonoBehaviour
    {
        public float speed = 1;
        public float mouseSpeed = 60;
       
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal"); 
            float vertical = Input.GetAxis("Vertical");
            float mouse = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(new Vector3(horizontal * speed, mouse * mouseSpeed, vertical * speed) * Time.deltaTime * speed, Space.World);
        }
    }
}

