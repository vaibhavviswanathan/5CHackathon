using UnityEngine;
using System.Collections;
using Leap;

public class ModeSelector : MonoBehaviour {

	// enumerate the modes of interaction
	const int PLAY_MODE = 0;
	const int EDIT_MODE = 1;
	const int LOOP_MODE = 2;

	int updateCounter = 0;
	bool switchedModes = false;
	Controller controller;
	public int currentMode = 0;

	// Use this for initialization
	void Start () {
		controller = new Controller();
		controller.EnableGesture (Gesture.GestureType.TYPECIRCLE, true);	
	
	}


	// Update is called once per frame
	void Update () {
		if (switchedModes)
			updateCounter += 1;
		if (updateCounter >= 60) {
			updateCounter = 0;
			switchedModes = false;
		}

		Frame frame = controller.Frame(); //The latest frame
		foreach (Gesture gesture in frame.Gestures())
		{
			switch(gesture.Type)
			{
			case(Gesture.GestureType.TYPECIRCLE):
				if(switchedModes == false){
					switchedModes = true;
					currentMode = (currentMode + 1)%3;
				}
				break;
			}
		}


		switch(currentMode){
		case(PLAY_MODE):
			GameObject.Find("Main Camera/TrackingSpace/CenterEyeAnchor/Canvas/Text").GetComponent<UnityEngine.UI.Text>().text = "Play Mode";
			break;
		case(EDIT_MODE):
			GameObject.Find("Main Camera/TrackingSpace/CenterEyeAnchor/Canvas/Text").GetComponent<UnityEngine.UI.Text>().text = "Edit Mode";
			break;
		case(LOOP_MODE):
			GameObject.Find("Main Camera/TrackingSpace/CenterEyeAnchor/Canvas/Text").GetComponent<UnityEngine.UI.Text>().text = "Loop Mode";
			break;
		}	
	}

	public int getCurrentMode(){
		return currentMode;
	}
}
