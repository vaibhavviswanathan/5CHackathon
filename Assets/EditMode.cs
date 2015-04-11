using UnityEngine;
using System.Collections;

public class EditMode : MonoBehaviour {

	public bool inEditMode;
	const int EDIT_MODE = 1;
	ModeSelector modeSelector;
	// Use this for initialization
	void Start () {
		modeSelector = this.GetComponentInParent<ModeSelector>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject targetObj = GameObject.Find("Main Camera"); // drag the object with the Clips variable here
		ModeSelector targetScript = targetObj.GetComponent<ModeSelector>();
		inEditMode = modeSelector.getCurrentMode() == EDIT_MODE;	



		if (inEditMode) {
			GameObject.Find("GUI/Text").GetComponent<UnityEngine.UI.Text>().text = "Edit Mode";

		}
	
	}
}
