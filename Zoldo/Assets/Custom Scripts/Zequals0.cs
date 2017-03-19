using UnityEngine;
using System.Collections;

public class Zequals0 : MonoBehaviour {

	public float zed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(transform.position.x,transform.position.y,zed);
	}
}
