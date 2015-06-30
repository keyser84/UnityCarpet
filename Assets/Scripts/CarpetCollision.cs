using UnityEngine;
using System.Collections;

public class CarpetCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter(Collision collision) {
		// ignore character lower part
		if(collision.collider.gameObject.name == "characterLowerUV")
			return;
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "Carpet!";
	}

	void OnCollisionExit(Collision collision) {
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "";
	}

}
