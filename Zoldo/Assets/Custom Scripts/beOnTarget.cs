using UnityEngine;
using System.Collections;

public class beOnTarget : MonoBehaviour {

	public GameObject targetb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		targetb = GetComponentInParent<PlayerControl>().targeted;
		if(targetb.gameObject.name == "defaultTarget"){
			GetComponent<SpriteRenderer>().enabled = false;
		} else {
			GetComponent<SpriteRenderer>().enabled = true;
		}
		transform.position = new Vector3 (targetb.transform.position.x,targetb.transform.position.y,targetb.transform.position.z - 0.1f);
	}
}
