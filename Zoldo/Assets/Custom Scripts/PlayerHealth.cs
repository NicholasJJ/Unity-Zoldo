using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHp;
	public float Hp;



	//private bool invincible;
	private float invinceibleTimer;
	public float iTime;
	private bool rollinvince;


	// Use this for initialization
	void Start () {
		Hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(Hp);
		invinceibleTimer = invinceibleTimer + Time.deltaTime;
		rollinvince = GetComponent<PlayerControl>().iroll;
		//GameObject.Find("hp").GetComponent<RectTransform>().localScale.x = Hp/50;
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "EnemyWeapon"){
			if(rollinvince == false && invinceibleTimer > iTime){
				Hp = Hp - col.gameObject.GetComponent<DamageOnContact>().damage;
				invinceibleTimer = 0f;
			}
		}
	}
	void OnGUI(){
		//GUI.Box(new Rect(Screen.width - xpos,Screen.height - ypos, length, height),Hp + " / " + maxHp);
	}
}
