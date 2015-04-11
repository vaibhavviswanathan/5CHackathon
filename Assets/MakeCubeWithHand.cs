using UnityEngine;
using System.Collections;
using Leap;


public class MakeCubeWithHand : MonoBehaviour {

	const int EDIT_MODE = 1;
	bool screentap = false;
	Controller controller;
	GameObject rightHand;
	Transform rIndexTip;
	Frame frame;
	public AudioClip cubeClip;
	ModeSelector modeSelector;
	// Use this for initialization
	void Start () {
		controller = new Controller();
		ELGManager.GestureRecognised += onGestureRecognised;
		ELGManager.circleGestureRegistered = true;
		ELGManager.twoFingerScreentapRegistered = true;
		ELGManager.screentapGestureRegistered = true;
		ELGManager.closeFistRegistered = true;
		controller.EnableGesture (Gesture.GestureType.TYPESWIPE, true);
		modeSelector = GameObject.Find("Main Camera").GetComponent<ModeSelector>();
	}
	
	// Update is called once per frame
	void Update () {
		frame = controller.Frame (); //The latest frame


		foreach (Gesture gesture in frame.Gestures()) {
			switch (gesture.Type) {
			case(Gesture.GestureType.TYPESWIPE):
				rightHand = GameObject.Find ("RigidHand(Clone)");
				rIndexTip = rightHand.transform.Find ("index/bone3");

				if (modeSelector.getCurrentMode () == EDIT_MODE)
					makeCube (rIndexTip.transform.position);
				break;
			}
		}
	}

	
	void onGestureRecognised(EasyLeapGesture gesture) {
		print ("IUIUBLUHLKBLJKBLKB");
		if(gesture.Type.Equals(EasyLeapGestureType.CLOSE_FIST)){
			rightHand = GameObject.Find ("RigidHand(Clone)");
			rIndexTip = rightHand.transform.Find ("index/bone3");
			if(modeSelector.getCurrentMode() == EDIT_MODE)
				makeCube(rIndexTip.transform.position);
		}
	}
	void makeCube(Vector3 pos)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.position = pos;
		cube.AddComponent<BoxCollider> ();
		AudioSource cubeSound = new AudioSource ();
		cube.AddComponent<AudioSource>();
		cube.GetComponent<AudioSource> ().clip = cubeClip;
		cube.GetComponent<AudioSource> ().loop = false;
		cube.AddComponent<CubeSound> ();
	}
}
