using UnityEngine;
using System.Collections;

public class CarpetControl : MonoBehaviour {
	
	private float acceleration = 60f;
	private float decelerationRatio = 0.5f;
	private float velocity;
	private float velocityMin = 0f;
	private float velocityMax = 80f;
	
	private float turnAcceleration = 600f;
	private float turnAngle;
	private float turnAngleMin = -150f;
	private float turnAngleMax = +150f;
	
	private float rollRatio = 0.2f;
	
	private float flyingHeightMin = 5.0f;
	private float fallingAcceleration = 50.0f;
	private float fallingVelocity;
	
	// Use this for initialization
	void Start () {
		velocity = 0;		
		turnAngle = 0;
		fallingVelocity = 0;
		//GameObject.Find("characterCarpet").animation["Default Take"].speed = 0;
		GameObject.Find("characterLowerUV").animation["Default Take"].speed = 0;
	}
	
	// Update is called once per frame
	void Update () {		
		
		// unroll
		/*
		transform.FindChild("carpetWaveUV").RotateAround(
			transform.position + new Vector3(0, 4, 0),
			transform.FindChild("carpetWaveUV").forward,
			rollRatio * turnAngle * velocity / velocityMax);
		*/
		// reset roll
		transform.FindChild("carpetWaveUV").localRotation = new Quaternion(0, 0, 0, 1);
		transform.FindChild("carpetWaveUV").localPosition = new Vector3(0, 0, 0);
				
		if(Input.GetKey(KeyCode.UpArrow)) {			
			// increase velocity
            velocity += acceleration * Time.deltaTime;
			if(velocity > velocityMax)
				velocity = velocityMax;
		}
        else if(Input.GetKey(KeyCode.DownArrow)) {
			// decrease velocity
			velocity -= acceleration * Time.deltaTime;
			if(velocity < velocityMin)
				velocity = velocityMin;
		}
		else {
			// decrease velocity (idle)
			velocity -= decelerationRatio * acceleration * Time.deltaTime;
			if(velocity < velocityMin)
				velocity = velocityMin;
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			// decrease turn angle
			turnAngle -= turnAcceleration * Time.deltaTime;
			if(turnAngle < turnAngleMin)
				turnAngle = turnAngleMin;
		}
        else if(Input.GetKey(KeyCode.RightArrow)) {
			// increase turn angle
            turnAngle += turnAcceleration * Time.deltaTime;
			if(turnAngle > turnAngleMax)
				turnAngle = turnAngleMax;
		}
		else {			
			if(turnAngle < 0) {
				// increase turn angle (idle)
				turnAngle += turnAcceleration * Time.deltaTime;
				if(turnAngle > 0)
					turnAngle = 0;
			}
			if(turnAngle > 0) {
				// decrease turn angle (idle)
				turnAngle -= turnAcceleration * Time.deltaTime;
				if(turnAngle < 0)
					turnAngle = 0;
			}
		}
		
		// turn
		transform.Rotate(Vector3.up * turnAngle * Time.deltaTime);		
		
		// forward
		transform.Translate(Vector3.forward * velocity * Time.deltaTime);
		
		// roll		
		transform.FindChild("carpetWaveUV").RotateAround(
			transform.position + new Vector3(0, 4, 0),
			transform.FindChild("carpetWaveUV").forward,
			rollRatio * -turnAngle * velocity / velocityMax);
		
		// init falling
		Vector3 positionTemp = transform.position;		
		
		// increase falling velocity
		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
		if(positionTemp.y > terrainHeight + flyingHeightMin)
			fallingVelocity += fallingAcceleration * Time.deltaTime;
		else
			fallingVelocity = 0;
		
		// fall
		positionTemp.y -= fallingVelocity * Time.deltaTime;
		if(positionTemp.y < terrainHeight + flyingHeightMin) {
			positionTemp.y = terrainHeight + flyingHeightMin;
		}
		
		// finalise falling
		transform.position = positionTemp;
				
		// animation carpet
		GameObject.Find("carpetWaveUV").animation["Default Take"].speed = velocity / velocityMax * 5;

		// animation legs
		float turnFrame = (-turnAngle / turnAngleMax * velocity / velocityMax) + 2.0f;
		//GameObject.Find("characterCarpet").animation["Default Take"].time = turnFrame;
		GameObject.Find("characterLowerUV").animation["Default Take"].time = turnFrame;
		
	}
	
}
