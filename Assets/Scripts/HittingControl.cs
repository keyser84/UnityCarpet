using UnityEngine;
using System.Collections;

public class HittingControl : MonoBehaviour {

	float hittingLeftTime = 2.0f;
	float hittingRightTime = 0.0f;
	float hittingDuration = 2.0f;
	float hittingSpeed = 3.0f;
	float hittingRange = 1.0f;
	bool hittingLeft;
	bool hittingRight;	
	
	// Use this for initialization
	void Start () {
		hittingLeft = false;
		hittingRight = false;
		GameObject.Find("characterUpperUV").animation["Default Take"].speed = 0;
		GameObject.Find("characterStick").animation["Default Take"].speed = 0;
	}
	
	// Update is called once per frame
	void Update () {		

		// adjust bounding box position		
		BoxCollider box = (BoxCollider) GameObject.Find("characterStick").GetComponent("BoxCollider");
		Vector3 boxCenter = box.center;		
		if(hittingLeft)
			boxCenter.x = -hittingRange;
		else if(hittingRight)
			boxCenter.x = +hittingRange;
		else
			boxCenter.x = 0.0f;
		box.center = boxCenter;
		
		// stop hitting
		if(hittingLeft) {
			if(GameObject.Find("characterUpperUV").animation["Default Take"].time >= hittingLeftTime + hittingDuration) {
				GameObject.Find("characterUpperUV").animation["Default Take"].speed = 0;
				GameObject.Find("characterStick").animation["Default Take"].speed = 0;
				hittingLeft = false;				
			}
		}
		else if(hittingRight) {
			if(GameObject.Find("characterUpperUV").animation["Default Take"].time >= hittingRightTime + hittingDuration) {
				GameObject.Find("characterUpperUV").animation["Default Take"].speed = 0;
				GameObject.Find("characterStick").animation["Default Take"].speed = 0;
				hittingRight = false;				
			}
		}
		
		if(Input.GetKey(KeyCode.A)) {
			// hit left
			GameObject.Find("characterUpperUV").animation["Default Take"].time = hittingLeftTime;
			GameObject.Find("characterUpperUV").animation["Default Take"].speed = hittingSpeed;
			GameObject.Find("characterStick").animation["Default Take"].time = hittingLeftTime;
			GameObject.Find("characterStick").animation["Default Take"].speed = hittingSpeed;
			hittingLeft = true;
			hittingRight = false;			
		}
		else if(Input.GetKey(KeyCode.D)) {
			// hit right
			GameObject.Find("characterUpperUV").animation["Default Take"].time = hittingRightTime;
			GameObject.Find("characterUpperUV").animation["Default Take"].speed = hittingSpeed;
			GameObject.Find("characterStick").animation["Default Take"].time = hittingRightTime;
			GameObject.Find("characterStick").animation["Default Take"].speed = hittingSpeed;
			hittingLeft = false;
			hittingRight = true;
		}
		
	}
	
}
