using UnityEngine;
using System.Collections;

public class xScaleBeHp : MonoBehaviour {

	private float hp;

	// Use this for initialization
	void Start () {
		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Hp;
		gameObject.GetComponent<RectTransform>().localScale = new Vector3(hp/100f,1f,1f);
	}
}
