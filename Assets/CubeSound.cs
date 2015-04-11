using UnityEngine;
using System.Collections;

public class CubeSound : MonoBehaviour {

	public bool inPlayMode;
	const int PLAY_MODE = 0;
	int playCounter = 0;
	int stopCounter = 0;
	bool isPlaying;
	// Use this for initialization
	ModeSelector modeSelector;
	// Use this for initialization
	void Start () {
		modeSelector = GameObject.Find ("Main Camera").GetComponent<ModeSelector> ();
		isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		inPlayMode = modeSelector.getCurrentMode() == PLAY_MODE;	


		
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collision Detected");
		
		if (other.gameObject.name == "CleanRobotLeftHand(Clone)" || other.gameObject.name == "RigidHand(Clone)")
		{
			if(inPlayMode)
				this.GetComponentInParent<AudioSource>().Play();
		
		}
	}
}
