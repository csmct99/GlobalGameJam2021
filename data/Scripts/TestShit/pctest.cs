using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "277760ea44f61b4175233bac0ccb831bc6a45dbe")]
public class pctest : Component
{
	[ShowInEditor]
	private float playerSpeed = 5000f;

	[ShowInEditor]
	private float cameraSpeed = 0.1f;

	[ShowInEditor]
	private Node camera;

	[ShowInEditor]
	private float clampX = 75;
	
	[ShowInEditor]
	private float clampY = 75;

[ShowInEditor]
	private float maxVel = 1f;

	private void Init()
	{
		if(camera == null){
			Log.FatalLine("No cam set");
		}
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}

	private void UpdatePhysics(){
		if(Input.IsKeyPressed(Input.KEY.W)){
			node.ObjectBodyRigid.AddForce(vec3.FORWARD * Game.IFps * playerSpeed); //new vec3(0,1,0;
			float x = node.ObjectBodyRigid.LinearVelocity.x;
			float y = node.ObjectBodyRigid.LinearVelocity.y;
			float z = node.ObjectBodyRigid.LinearVelocity.z;
			node.ObjectBodyRigid.LinearVelocity = new vec3(Math.Clamp(x, -maxVel, maxVel), Math.Clamp(y, -maxVel, maxVel), Math.Clamp(z, -maxVel, maxVel));
		}

		//For clamping look direction, I suggest u either check the Euler angles of the camera per frame and lock them OR keep a running tally of the delta euler angles you have changed and uise that as the current value to clamp against.

		ivec2 mouseDelta = Input.MouseCoordDelta;
		if(mouseDelta != ivec2.ZERO){ //aka if the mouse moved last frame
			camera.WorldRotate(new quat(-mouseDelta.y,0,0));
		}
	}
} 
