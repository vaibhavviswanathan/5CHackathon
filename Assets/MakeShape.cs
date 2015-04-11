using UnityEngine;
using System.Collections;

public class MakeShape : MonoBehaviour {


	ArrayList shapes;
	// Use this for initialization
	void Start () {
		shapes = new ArrayList();
	}

	void makeCube(){
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		shapes.Add(cube);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
			makeCube ();

		 	
		
	
	}
}
