using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "a1d8496fcd83e802e2c4877949350a841d351413")]
public class PlayerController : Component
{

	public PlayerDummy camera;

	private void Init()
	{

		//Check for missing manual variables
		if(camera == null){

			Log.FatalLine("Player Controller : a value was not assigned");
		}

		//Make the camera Orthographic
		camera.Projection = MathLib.Ortho (-1.0f, 1.0f, -1.0f, 1.0f, camera.ZNear, camera.ZFar + 10000);
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}