#pragma strict

var accelerometerUpdateInterval : float = 1.0 / 60.0;
// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
var lowPassKernelWidthInSeconds : float = 1.0;
// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
var shakeDetectionThreshold : float = 2.0;

var shaking : boolean = false;

private var lowPassFilterFactor : float = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
private var lowPassValue : Vector3 = Vector3.zero;
private var acceleration : Vector3;
private var deltaAcceleration : Vector3;

function Start()
{
    shakeDetectionThreshold *= shakeDetectionThreshold;
    lowPassValue = Input.acceleration;
}

function Update()
{
    acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        deltaAcceleration = acceleration - lowPassValue;
    if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold || Input.GetKeyDown("f"))
    {
        // Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.
        Debug.Log("Shake event detected at time "+Time.time);
        shaking = true;
    } else {
    	shaking = false;
    }
}