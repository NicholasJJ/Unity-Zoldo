using UnityEngine;
using System.Collections;

public class forwardBackward : MonoBehaviour {

	private float height;
	private bool up;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		up = GetComponentInParent<PlayerControl>().weaponAbove;
		if(up == false){
			height = -0.01f;
		} else if (up == true){
			height = 0.01f;
		}
		transform.position = new Vector3 (transform.position.x,transform.position.y,height);
	}
}
