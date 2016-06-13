using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public float speed = 5f;
    public float jumpspeed = 6f;
    private Vector3 movederection = Vector3.zero;
    private float gravity = 20f;
    //判断物体是否处于地面上
    private bool grounded = false;
    
	void Update () {

        
        
        if (grounded != true)
        {
            movederection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); ;
            movederection = transform.TransformDirection(movederection);
            //计算在方向上单位时间移动的距离
            movederection *= speed;
            if (Input.GetButton("Jump")) {

                movederection.y = jumpspeed;
            }
        }

        movederection.y -= gravity * Time.deltaTime ;
        CharacterController controller = GetComponent<CharacterController>();
        //移动命令
        var flags = controller.Move(movederection * Time.deltaTime);
        grounded = (flags & CollisionFlags.CollidedBelow) != 0;
       
       
	}

   // [RequireComponent(typeof(CharacterController))]
}
