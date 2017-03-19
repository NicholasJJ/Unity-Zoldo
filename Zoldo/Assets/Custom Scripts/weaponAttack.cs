using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class weaponAttack : MonoBehaviour {

	private bool weaponIsAttacking;
	private float ATKTimer;
	public float StrikeFrequency;
	private bool CanATK;
	public float StrikeSpeed;
	public float Damage;

	private bool rolling;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ATKTimer = ATKTimer + Time.deltaTime;
		rolling = GetComponentInParent<PlayerControl>().rolling;
		if(ATKTimer > StrikeSpeed){
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		}
		weaponIsAttacking = CrossPlatformInputManager.GetButton("ATK");
		if ((weaponIsAttacking == true || Input.GetButtonDown("Jump"))&& ATKTimer > StrikeFrequency && CanATK == true && rolling == false){
			ATKTimer = 0;
			Debug.Log("attacking");
			gameObject.GetComponent<PolygonCollider2D>().enabled = true;
			CanATK = false;
		} else if (weaponIsAttacking == false){
			CanATK = true;
		}
	}

}
