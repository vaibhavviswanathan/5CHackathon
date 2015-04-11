using UnityEngine;
using System.Collections;

public class CubeSound : MonoBehaviour {

	public bool inPlayMode;
	const int PLAY_MODE = 0;
	bool isPlaying;
	// Use this for initialization
	ModeSelector modeSelector;
	// Use this for initialization
	void Start () {
		print(this.gameObject.name);
		modeSelector = this.GetComponentInParent<ModeSelector> ();
		isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		inPlayMode = modeSelector.getCurrentMode() == PLAY_MODE;	
		
		
		
		if (inPlayMode) {
			GameObject.Find("GUI/Text").GetComponent<UnityEngine.UI.Text>().text = "Play Mode";
		}
		
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collision Detected");
		
		if (other.gameObject.tag == "CleanRobotLeftHand(Clone)" || other.gameObject.tag == "CleanRobotRightHand(Clone)")
		{
			if(!isPlaying){
				this.GetComponentInParent<AudioSource>().Play();
				isPlaying = true;
			}

			if(isPlaying){
				this.GetComponentInParent<AudioSource>().Stop();
				isPlaying = false;
		}
		
		}
	}
}
