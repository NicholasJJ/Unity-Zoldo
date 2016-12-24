using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class touchToTarget : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
		void Update () {
		
		if (/*Input.GetMouseButtonDown(0)*/  Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			Debug.Log("mouse down");
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Enemy")
			{
				target = hit.transform.gameObject;
			}
		}
}
}