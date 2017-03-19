using UnityEngine;
using System.Collections;

public class ShakeDetector : MonoBehaviour {

	public float acUpdateSpeed = 0.016666667f;
	public float lowPassWithinSeconds = 1.0f;
	public float detectionThreshold = 2.0f;
	public bool shaking = false;

	private float lowPassFilterFactor;
	private Vector3 lowPassValue = Vector3.zero;
	private Vector3 ac;
	private Vector3 deltaAc;


	// Use this for initialization
	void Start () {
		lowPassFilterFactor = acUpdateSpeed/lowPassWithinSeconds;
		detectionThreshold *= detectionThreshold;
		lowPassValue = Input.acceleration;
	}
	
	// Update is called once per frame
	void Update () {
		ac = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue,ac,lowPassFilterFactor);
		deltaAc = ac - lowPassValue;

		if(deltaAc.sqrMagnitude >= detectionThreshold || Input.GetKey("f")){
			Debug.Log("detectiong Shake");
			shaking = true;
		} else{
			shaking = false;
		}
	}
}
