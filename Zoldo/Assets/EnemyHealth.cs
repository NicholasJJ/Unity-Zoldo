using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private float hp;
	public float MaxHp;

	// Use this for initialization
	void Start () {
		hp = MaxHp;
	}
	
	// Update is called once per frame
	void Update () {
		if(hp <= 0){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log("collider is " + col.gameObject.name);
		if (col.gameObject.tag == "Weapon"){
			hp = hp - col.gameObject.GetComponent<weaponAttack>().Damage;
		}
	}
}
