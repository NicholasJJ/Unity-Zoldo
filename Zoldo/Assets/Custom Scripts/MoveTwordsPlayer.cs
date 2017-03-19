using UnityEngine;
using System.Collections;

public class MoveTwordsPlayer : MonoBehaviour {

	private GameObject player;
	public float speed;
	private Rigidbody2D rig;
	private float playerAngle;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		playerAngle = Mathf.Atan((player.transform.position.y - transform.position.y)/(player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;
		if(player.transform.position.x < transform.position.x){
			playerAngle = playerAngle + 180f;
		}
		rig.MoveRotation(playerAngle);
		transform.Translate(new Vector3(speed,0f));
	}
}
