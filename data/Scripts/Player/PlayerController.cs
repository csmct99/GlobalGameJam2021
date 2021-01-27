using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "a1d8496fcd83e802e2c4877949350a841d351413")]
public class PlayerController : Component
{

	[Parameter(Group="Referances")]
	public PlayerDummy camera;

	[Parameter(Group="Input")]
	public Input.KEY upInput = Input.KEY.W;

	[Parameter(Group="Input")]
	public Input.KEY downInput = Input.KEY.W;
	
	[Parameter(Group="Input")]
	public Input.KEY leftInput = Input.KEY.W;
	
	[Parameter(Group="Input")]
	public Input.KEY rightInput = Input.KEY.W;

	[Parameter(Group="Settings")]
	public float movementSpeed = 10f;
	

	private void Init()
	{

		//Check for missing manual variables
		if(camera == null){

			Log.FatalLine("Player Controller : a value was not assigned");
		}

		//Make the camera Orthographic
		camera.Projection = MathLib.Ortho (-1.0f, 1.0f, -1.0f, 1.0f, camera.ZNear, camera.ZFar + 10000);
		
	}
	
	private void Update() {
		Movement();
			
	}

	private void Movement(){ //Collect 
		vec3 desiredDirection = vec3.ZERO;

		if(Input.IsKeyPressed(upInput)){
			desiredDirection += vec3.FORWARD;
		} else if(Input.IsKeyPressed(downInput)){
			desiredDirection += vec3.BACK;
		}

		if(Input.IsKeyPressed(leftInput)){
			desiredDirection += vec3.LEFT;
		} else if(Input.IsKeyPressed(rightInput)){
			desiredDirection += vec3.RIGHT;
		}

		node.WorldTranslate(desiredDirection.Normalize() * movementSpeed * Game.IFps);
	}
}