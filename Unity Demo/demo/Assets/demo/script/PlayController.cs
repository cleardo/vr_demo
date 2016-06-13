using UnityEngine;
using System.Collections;

public class PlayController : MonoBehaviour
{
    
    //人物行走的4个方向
    public const int PLAY_UP = 0;
    public const int PLAY_RIGHT = 1;
    public const int PLAY_DOWN = 2;
    public const int PLAY_LEFT = 3;
    

    //记录当前人物的状态
    private int gameState = 0;

    //定义GameObj的移动的速度
    private int moveSpeed = 7;

    void Awake()
    {
        //初始化当前状态,定义初始位置
        gameState = PLAY_UP;
          
    }

    void Update()
    {
        //初始化键盘键值
        if (Input.GetKey(KeyCode.A))
        {
            setGameState(PLAY_LEFT);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            setGameState(PLAY_RIGHT);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            setGameState(PLAY_DOWN);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            setGameState(PLAY_UP);
        }
    }
 
    public void setGameState(int newState)
    {
        //计算当前模型需要旋转的角度
        int rotareValue = (newState - gameState) * 90;
        Vector3 transFormValue = new Vector3();
       

        //模型移动的数值
        switch (newState)
        {
            case PLAY_UP:
                transFormValue = Vector3.forward * Time.deltaTime;
                break;
            case PLAY_DOWN:
                transFormValue = (Vector3.back) * Time.deltaTime;
                break;
            case PLAY_LEFT:
                transFormValue = Vector3.left * Time.deltaTime;
                break;
            case PLAY_RIGHT:
                transFormValue = (Vector3.right) * Time.deltaTime;
                break;
        }
        //模型旋转
        transform.Rotate(Vector3.up*Time.deltaTime,rotareValue);
     
       

        //移动人物
        transform.Translate(transFormValue * moveSpeed, Space.World);
          gameState = newState;

    }
}