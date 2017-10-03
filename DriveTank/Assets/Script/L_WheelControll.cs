using UnityEngine;
using System.Collections;

public class L_WheelControll : MonoBehaviour
{

    public Vector3 weelRotateSpeed;
    void FixedUpdate()
    {
        if (Input.GetKey("w"))//前進
        {
            transform.Rotate(-weelRotateSpeed.x * (float)PlayerController.gearPower, 0, 0);
          //  rigidbody.AddRelativeTorque(-weelRotateSpeed.x * (float)PlayerController.gearPower, 0, 0);　//力を加えないとキャタピラが回ってくれないのでは？
        }

        if (Input.GetKey("s"))//後退
        {
            transform.Rotate(weelRotateSpeed.x *(float)PlayerController.gearPower, 0, 0);
        }
        if (Input.GetKey("a"))//左旋回の場合　左履帯は後退する
        {
            transform.Rotate(weelRotateSpeed.x * (float)PlayerController.gearPower, 0, 0);
        }
        if (Input.GetKey("d"))//右旋回の場合　左履帯は前進する
        {
            transform.Rotate(-weelRotateSpeed.x * (float)PlayerController.gearPower, 0, 0);
        }


    }
}

