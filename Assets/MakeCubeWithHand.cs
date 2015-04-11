using UnityEngine;
using System.Collections;
using Leap;

public class MakeCubeWithHand : MonoBehaviour {
	
	bool screentap = false;
	Controller controller;
	GameObject leftHand;
	Transform lIndexTip;
	// Use this for initialization
	void Start () {
		controller = new Controller();
		controller.EnableGesture (Gesture.GestureType.TYPESCREENTAP, true);	
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame(); //The latest frame
		HandList handList = frame.Hands;

		if (GameObject.Find ("CleanRobotLeftHand(Clone)") != null) {
			leftHand = GameObject.Find ("CleanRobotLeftHand(Clone)");
			lIndexTip = leftHand.transform.Find ("index/bone3");
		}

		foreach (Gesture gesture in frame.Gestures())
		{
		switch(gesture.Type)
			{
			case(Gesture.GestureType.TYPESCREENTAP):
				Finger indexFinger = frame.Hands [0].Fingers [(int)Finger.FingerType.TYPE_INDEX];
				// take raw value and conver using ToUnityScaled()
				Vector3 fingerTipPos = indexFinger.TipPosition.ToUnityScaled ();
				makeCube(fingerTipPos);
				break;
			}
		}


	}

	void makeCube(Vector3 pos)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.position = pos;
		cube.AddComponent<BoxCollider> ();
		AudioSource cubeSound = new AudioSource ();
		cube.AddComponent<AudioSource>();
		cube.GetComponent<AudioSource>().clip = Resources.Load("Assets/sounds/drum_loops/drum_loop") as AudioClip;
		cube.GetComponent<AudioSource> ().loop = true;
		cube.AddComponent<CubeSound> ();
	}
}
