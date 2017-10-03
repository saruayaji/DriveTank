using UnityEngine;
using System.Collections;

public class tanksoundController : MonoBehaviour {
    public AudioSource audiosource;
    public tankControll tankcontroll;
    public float maxSpeed=1;
    public float maxPichSpeed=1;
    public float speed=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //speed = Input.GetAxis("Horizontal");
        speed = tankcontroll.speed;
        audiosource.pitch = 1 + ((Mathf.Abs(speed) / maxSpeed) * (maxPichSpeed-1));
	}
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
