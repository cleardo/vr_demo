using UnityEngine;
using System.Collections;

public class UpControl : MonoBehaviour
{
    //给附体赋予初始速度，使物体延y轴运动
    //初始速度
    public float movespeed = 5f;

    void Update()
    {

        Vector3 sudu = new Vector3(0, movespeed * 2f, 0);
        GetComponent<Rigidbody>().velocity = sudu;
    }
}
