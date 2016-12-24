using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	public bool isAttacking;
	private float atkTimer;
	public float atkSpeed;
	private string weaponName;

	//public GameObject weapon;
	private Vector3 weaponStartPos;
	public bool weaponAbove;

	Rigidbody2D myBody;
	private bool canAtk;

	public bool rolling;
	public bool iroll;
	private float rollTimer;
	public float invinTime;
	public float rollTime;
	public float invinSpeed;
	public float rollSpeed;

	public GameObject targeted;
	public GameObject defaultTarget;



	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		rolling = false;
		rollTimer = 0;
		targeted = GameObject.Find("defaultTrget");
		iroll = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rolling = GetComponent<ShakeDetector>().shaking;
		if (rollTimer > 0){
			rolling = true;
		}
		atkTimer = atkTimer+Time.deltaTime;
		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		isAttacking = CrossPlatformInputManager.GetButton("ATK");

		////

		if(GetComponentInChildren<touchToTarget>().target != null ){
			Debug.Log("there is a target");
			targeted = GetComponentInChildren<touchToTarget>().target;
		} else {
			Debug.Log("setting target to default");
			targeted = defaultTarget;
		}
		if (targeted.transform.position.y >= transform.position.y){
			weaponAbove = true;
		} else {
			weaponAbove = false;
		}

		////
		if(rolling == true){
			rollTimer = rollTimer + Time.deltaTime;
			iroll = true;
			if(rollTimer <= invinTime){
				transform.position = transform.position + transform.right*moveSpeed*invinSpeed;
			} else if (rollTimer <= rollTime){
				transform.position = transform.position + transform.right*moveSpeed*rollSpeed;
				iroll = false;
			} else {
				rollTimer = 0;
				iroll = false;
			}

		} else if((moveVec.x != 0 || moveVec.y != 0) && atkTimer >= atkSpeed){
			float moveRot = Mathf.Acos(moveVec.x/Mathf.Sqrt((moveVec.x)*(moveVec.x)+(moveVec.y)*(moveVec.y)))*Mathf.Rad2Deg;
			//weaponAbove = true;
				if (moveVec.y < 0){
					moveRot = moveRot * -1f;
				//weaponAbove = false;
				}
			myBody.MoveRotation(moveRot);
			transform.position = transform.position + transform.right*moveSpeed;
		}

		if ((isAttacking == true || Input.GetButtonDown("Jump"))&& atkTimer > atkSpeed && canAtk == true){
			atkTimer = 0;
			canAtk = false;
		} else if (isAttacking == false){
			canAtk = true;
		}


	}
	void OnTriggerEnter2D(Collider2D col){
//		Debug.Log("collided w/ something");
		if(col.gameObject.tag == "WeaponMaker"){
//			Debug.Log("that thing is a weapon maker!");
			GameObject.Destroy(GameObject.FindGameObjectWithTag("Weapon"));
			weaponName = col.gameObject.name + "W";
			GameObject.Instantiate(Resources.Load(weaponName),transform.position,transform.rotation,transform);
			GameObject.Destroy(col.gameObject);
		}
	}
}
