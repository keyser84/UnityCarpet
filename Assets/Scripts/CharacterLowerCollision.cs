using UnityEngine;
using System.Collections;

public class CharacterLowerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		// ignore carpet
		if(collision.collider.gameObject.name == "carpetWaveUV")
			return;
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "Character Lower!";
	}

	void OnCollisionExit(Collision collision) {
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "";
	}

}
