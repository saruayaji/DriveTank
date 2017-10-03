using UnityEngine;
using System.Collections;

public class R_CaterpillarScroll : MonoBehaviour
{

    [SerializeField]
    private double scrollSpeedX = 0.1f;


    private double SPEED = 0.1;
    private int stop_flag = 1;//停車しているかしていないか。初期値は停止


    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);

    }

    void Update()
    {


        if (Input.GetKey("w"))//前進した場合前に回転
        {
            scrollSpeedX = -SPEED * (PlayerController.gearPower) * (PlayerController.gearPower);
            stop_flag = 0;
        }
        else if (Input.GetKey("s"))//後退したら後ろ回転
        {
            scrollSpeedX = SPEED * (PlayerController.gearPower) * (PlayerController.gearPower);
            stop_flag = 0;
        }
        else if (Input.GetKey("a"))//左旋回の場合　左履帯は後退する
        {
            scrollSpeedX = -SPEED * (PlayerController.gearPower) * (PlayerController.gearPower);
            stop_flag = 0;
        }
        else if (Input.GetKey("d"))//右旋回の場合　左履帯は前進する
        {
            scrollSpeedX = SPEED * (PlayerController.gearPower) * (PlayerController.gearPower);
            stop_flag = 0;
        }
        else stop_flag = 1;//何も入力されていないときに、履帯回転は停止する


        if (stop_flag == 0)
        {
            var x = Mathf.Repeat(Time.time * (float)scrollSpeedX, 1);

            // var y = Mathf.Repeat( (float)scrollSpeedX, 1);

            var offset = new Vector2(x, 0);

            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }


    }
}