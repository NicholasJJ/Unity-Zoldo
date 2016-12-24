using UnityEngine;
using System.Collections;

public class SwingNSheith : MonoBehaviour {

	//private Vector3 axis;
	//public float speed;
	//private GameObject player;
	//private Vector3 playerPos;
	public float deathTimer;
	public float deathTime;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag("Player");
		//transform.RotateAround(playerPos,Vector3.forward,-90);
	}
	
	// Update is called once per frame
	void Update () {
		if(deathTimer > deathTime){
			Destroy(gameObject);
		}
		deathTimer = deathTimer + Time.deltaTime;
		//playerPos = player.transform.position;
		//axis = GameObject.FindGameObjectWithTag("Player").transform.position;
		//axis = new Vector3 (playerPos.x,playerPos.y,playerPos.z);
		
		//transform.RotateAround(playerPos,Vector3.forward,speed*Time.deltaTime);
		//transform.Rotate(Vector3.forward,speed*Time.deltaTime);
	}
}
