using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    public Vector3 rotatespeed;
    void FixedUpdate()
    {

        if (Input.GetKey("j"))
        {
            // jが押され続けてる！(シューティングのAuto Fireなどに使う)
          //  rigidbody.AddRelativeTorque(rotatespeed.x,- rotatespeed.y, -rotatespeed.z);
            transform.Rotate( rotatespeed.x, -rotatespeed.y, -rotatespeed.z);
        }
        if (Input.GetKey("k"))
        {
            // kが押され続けてる！(シューティングのAuto Fireなどに使う)
            //    rigidbody.AddRelativeTorque(rotatespeed.x, rotatespeed.y, rotatespeed.z);
            transform.Rotate(rotatespeed.x, rotatespeed.y, rotatespeed.z);

        }

        // xとzに10をかけて押す力をアップ
        // rigidbody.AddRelativeForce(z * 30, 0, x * 30);//ローカル座標で移動
        // rigidbody.AddRelativeForce(Vector3.forward * x);

    }
}