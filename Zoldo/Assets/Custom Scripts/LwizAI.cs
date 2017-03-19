using UnityEngine;
using System.Collections;

public class LwizAI : MonoBehaviour {

	public GameObject lazer;
	public float speed;
	public float range;
	public float loopTime;
	public Vector3 NextPos;
	public float rotSpeed;
	public float lazerMaxDist;

	private float timer;
	private float lazerDist;


	// Use this for initialization
	void Start () {
		timer = 0;
		NextPos = new Vector3(transform.position.x + Random.Range(-range,range),transform.position.y + Random.Range(-range,range),0f);
		//Debug.Log(5^2);

	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if(timer <= loopTime/2){
			move();
		} else if (timer <= loopTime){
			shoot();
		} else if (timer > loopTime){
			NextPos = new Vector3(transform.position.x + Random.Range(-range,range),transform.position.y + Random.Range(-range,range),0f);
			timer = 0;
		}
	}

	void move(){
		Debug.Log("wizard moving");
		if(transform.position != NextPos){
			transform.position = new Vector3 (Mathf.Lerp (transform.position.x, NextPos.x, speed), Mathf.Lerp (transform.position.y, NextPos.y, speed), Mathf.Lerp (transform.position.z, NextPos.z, speed));
		}
	}

	void shoot(){
		RaycastHit2D hit = Physics2D.Raycast( transform.position + (transform.right * 2), transform.right * 5 ,lazerMaxDist);
		if(hit.collider != null && hit.collider.name != "WizLazer(Clone)"){
			lazerDist = Mathf.Sqrt(Mathf.Pow(transform.position.x - hit.transform.position.x ,2f) + Mathf.Pow(transform.position.y - hit.transform.position.y,2f));
		} else {
			Debug.Log("Lazer ray didn't hit anything");
			lazerDist = lazerMaxDist;
		}

		GameObject curLazer = GameObject.Instantiate(lazer, transform.position + (transform.right * (lazerDist/2)) , transform.rotation) as GameObject;
		curLazer.transform.localScale = new Vector3(lazerDist,1,1);

		transform.Rotate(new Vector3(0,0,rotSpeed));
	}
}

