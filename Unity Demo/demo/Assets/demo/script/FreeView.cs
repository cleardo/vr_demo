using UnityEngine;
using System.Collections;

public class FreeView : MonoBehaviour
{

    //观察目标
    public Transform Target;

    //观察距离
    public float Distance = 5F;

    //旋转速度
    private float SpeedX = 240;
    private float SpeedY = 120;

    //角度限制
    private float MinLimitY = -180;
    private float MaxLimitY = 180;

    //旋转角度
    private float mX = 0.0F;
    private float mY = 0.0F;

    //是否启用差值
    public bool isNeedDamping = true;
    //速度
    public float Damping = 10F;

    //存储角度的四元数
    private Quaternion mRotation;

 
    void Start()
    {
        //初始化旋转角度
        mX = transform.eulerAngles.x;
        mY = transform.eulerAngles.y;
        Target = GameObject.Find("C001_Char").transform;
    }

    void LateUpdate()
    {
        //鼠标右键旋转
        if (Target != null && Input.GetMouseButton(1))
        {
            //获取鼠标输入
            mX += Input.GetAxis("Mouse X") * SpeedX * 0.02F;
            mY -= Input.GetAxis("Mouse Y") * SpeedY * 0.02F;
            //范围限制
            mY = ClampAngle(mY, MinLimitY, MaxLimitY);
            //计算旋转
            mRotation = Quaternion.Euler(mY, mX, 0);
            //根据是否差值采取不同的角度计算方式
            if (isNeedDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, mRotation, Time.deltaTime * Damping);
            }
            else
            {
                transform.rotation = mRotation;
            }
        }

        //重新计算位置
        Vector3 mPosition = mRotation * new Vector3(0.0F, 0.0F, -Distance) + Target.position;

        //设置相机的位置
        if (isNeedDamping)
        {
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping);
        }
        else
        {
            transform.position = mPosition;
        }

    }


    //角度限制
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}