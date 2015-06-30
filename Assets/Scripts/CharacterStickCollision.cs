using UnityEngine;
using System.Collections;

public class CharacterStickCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		// ignore character upper part
		if(collision.collider.gameObject.name == "characterUpperUV")
			return;
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "Stick!";
	}

	void OnCollisionExit(Collision collision) {
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "";
	}
	
}
