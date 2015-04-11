using UnityEngine;
using System.Collections;
using Leap;

public class ModeSelector : MonoBehaviour {

	// enumerate the modes of interaction
	const int PLAY_MODE = 0;
	const int EDIT_MODE = 1;
	const int LOOP_MODE = 2;

	Controller controller;
	int currentMode = 0;

	// Use this for initialization
	void Start () {
		controller = new Controller();
		controller.EnableGesture (Gesture.GestureType.TYPECIRCLE, true);	
	
	}


	// Update is called once per frame
	void Update () {
	
		Frame frame = controller.Frame(); //The latest frame
		foreach (Gesture gesture in frame.Gestures())
		{
			switch(gesture.Type)
			{
			case(Gesture.GestureType.TYPECIRCLE):
				currentMode = (currentMode + 1)%3;
				break;
			}
		}


		switch(currentMode){
		case(PLAY_MODE):
			break;
		case(EDIT_MODE):
			break;
		case(LOOP_MODE):
			break;
		}	
	}
}
