using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    //定义gameobj
    public GameObject target;
    //这个向量用于表示游戏开始时，注视点sight的坐标和摄像机坐标的差值
    public Vector3 offset;

    public float velocity;
    //摄像机的旋转角度
    private float currentAngleX;
    private float currentAngleY;
    //xxxxx
    Quaternion rotation = Quaternion.Euler(0,0,0);

	// Use this for initialization
	void Start () {
        //初始化计算camera与游戏角色的坐标差值
        offset = target.transform.position - transform.position;
        currentAngleX = 0;
        currentAngleY = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //读取以X轴为轴心获取gameobj的期望旋转角度
        float desireAngleY = target.transform.eulerAngles.x;
        //读取以Y轴为轴心获取gameobj的期望旋转角度
        float desireAngleX = target.transform.eulerAngles.y;

        rotation = Quaternion.Euler(0, desireAngleX, desireAngleY);
        transform.position = target.transform.position - (rotation * offset);
        transform.LookAt(target.transform);

	}
}
