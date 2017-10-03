using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tankControll : MonoBehaviour {
    public bool onTerrainFlag;
    public float powersize=0;
    public float rotsize = 0;
    public float totalSpeed = 0;
	public SerialHandler serialHandler;
    public Vector3 getL, getR;
	public Rigidbody rb;
    public float speed=0;
    public float acc=0;
    public float differentialspeed=0;
    public float maxspeed = 0;
    public float backmaxspeed = 0;
    // Use this for initialization
    void Start () {
		serialHandler.OnDataReceived += OnDataReceived;
		getL = new Vector3();
		getR = new Vector3();
	}
	void Update ()
	{
        //移動
        if (speed > maxspeed && speed < backmaxspeed)
            speed += (getL.z + getR.z) * acc * Time.deltaTime;//制限速度以内なら加速
	    speed -= (speed>0 ?1:-1) *differentialspeed*Time.deltaTime;//抗力としての減速
        Vector3 moveDirection = new Vector3(0,0,speed);//移動量
	    moveDirection = transform.TransformDirection(moveDirection);
        GetComponent<Rigidbody>().MovePosition(transform.position+moveDirection);

        //旋回
        if (onTerrainFlag)
            transform.Rotate(0, getL.y * rotsize / 2 + getR.y * rotsize / 2, 0);
	}
	void OnDataReceived(string message)
	{   
		int getint = int.Parse(message);
        Debug.Log(getint);
		if (getint > 127)
		{
			//左側
			getint -= 128;//左右確認用の値を抜く
			getint -= 63;//中心が63なので
            if (!(getint < 5 && getint > -5))
                getL = new Vector3(0, (float)getint / 64f, (float)-getint / 64f);
            else getL = new Vector3();
		}
		else
		{
			//右側
			getint -= 63;
            if (!(getint < 5 && getint > -5))
			    getR = new Vector3(0, (float)-getint/64f, (float)-getint/64f);
            else getR = new Vector3();
		}
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")//terrainと接触した場合　接触フラグはtrue
            onTerrainFlag = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")//terrainと離れた場合　　接触フラグはfalse
            onTerrainFlag = false;
    }
}


