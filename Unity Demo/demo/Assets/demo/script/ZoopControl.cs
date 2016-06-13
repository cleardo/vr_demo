using UnityEngine;
using System.Collections;

public class ZoopControl : MonoBehaviour {
	void Update () {

        //缩小
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 80)
            {
                Camera.main.fieldOfView += 2;
            }

            if (Camera.main.orthographicSize <= 20)
            {
                Camera.main.orthographicSize += 0.5F;
            }
               
        }
        //放大
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 10)
            {
                Camera.main.fieldOfView -= 2;
            }

            if (Camera.main.orthographicSize >= 1)
            {
                Camera.main.orthographicSize -= 0.5F;
            }
                
        }
      
	}
}
