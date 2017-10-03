using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    // speedを制御する
    public Vector3 speed;
    public static Vector3 playerVelocity;
    public static double gearPower = 0.3;//各ギアによっての出力パワー
    public static int onTerrainFlag;
    public  Rigidbody rb;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown("g"))//gを押した瞬間のみ反応
        {
            if (gearPower >= 0.5) gearPower = 0.3;//１超えたら初期に戻す
            else gearPower *= 1.1;

        }
        rb = GetComponent<Rigidbody>();
       // CalcWheelVelocity(transform.localPosition);



        //Rigidbody rigidbody = GetComponent<Rigidbody>();
        //旋回
        if (onTerrainFlag == 1)
            transform.Rotate(0, (x * speed.y) * (float)gearPower, 0);
        //rigidbody.AddRelativeTorque(0, (x * speed.y)*(float)gearPower, 0);

        //前進＆後退
        if (onTerrainFlag == 1)
            rb.AddRelativeForce((z * speed.x) * (float)gearPower, 0, (z * speed.z) * (float)gearPower);
    }


    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "terrain")//terrainと接触した場合　接触フラグが立つ
            onTerrainFlag = 1;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")//terrainと離れた場合　不接触フラグが立つ
            onTerrainFlag = 0;
    }

    //void CalcWheelVelocity(Vector3 localWheelPos)//速度を取得する
    //{
        //rb.velocity.magnitude

    //    playerVelocity = -rb.GetRelativePointVelocity(localWheelPos);
    //}
}