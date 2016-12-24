using UnityEngine;
using System.Collections;

public class TargetLook : MonoBehaviour {

	private GameObject target;
	private Vector3 diff;
	private float targetAngle;
	private Rigidbody2D rig;
	//private Rigidbody2D myRig;

	// Use this for initialization
	void Start () {
		rig = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(GetComponentInParent<PlayerControl>().targeted != null){
			target = GetComponentInParent<PlayerControl>().targeted;
			Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);


			targetAngle = Mathf.Atan((target.transform.position.y - transform.position.y)/(target.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;
			if(target.transform.position.x < transform.position.x){
				targetAngle = targetAngle + 180f;
			}
			rig.MoveRotation(targetAngle);

		} else {
			Debug.Log("weapon  not getting target");
		}

}
}
