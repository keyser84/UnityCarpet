using UnityEngine;
using System.Collections;

public class CharacterUpperCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "Character Upper!";
	}

	void OnCollisionExit(Collision collision) {
		TextMesh textMain = (TextMesh) GameObject.Find("TextMain").GetComponent("TextMesh");
		textMain.text = "";
	}

}
