using UnityEngine;
using System.Collections;

public class LeapRotate : MonoBehaviour {

	GameObject handController;
	GameObject eyeAnchor;
	float lastYRotate;
	// Use this for initialization
	void Start () {
		handController = GameObject.Find ("HandController");
		eyeAnchor = GameObject.Find ("Main Camera/TrackingSpace/CenterEyeAnchor");
		lastYRotate = eyeAnchor.GetComponent<Transform> ().rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
		float Yrotation = handController.GetComponent<Transform> ().rotation.y + 
			(eyeAnchor.GetComponent<Transform> ().rotation.y - lastYRotate);

		Quaternion newRotation = handController.transform.rotation;
		newRotation [1] = Yrotation;
		handController.transform.rotation = newRotation;
		lastYRotate = eyeAnchor.GetComponent<Transform> ().rotation.y;
	
	}
}
