using System;
using System.Collections;
using System.Collections.Generic;
using Vector2 = Unigine.vec2;
using Vector3 = Unigine.vec3;
using Vector4 = Unigine.vec4;
using Unigine;

[Component(PropertyGuid = "b934a7b7ffcd61aa9860a501982eba6cc9a172db")]
public class PlayerCharacter : Component
{

	public float PlayerSpeed = 10.0f;
	public float playerTurnSpeed = 80.0f;

	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Forward Movement")]
	private Input.KEY forwardMove = Input.KEY.W;

	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Backward Movement")]
	private Input.KEY backwardMove = Input.KEY.S;
	
	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Left Movement")]
	private Input.KEY leftMove = Input.KEY.A;
	
	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Right Movement")]
	private Input.KEY rightMove = Input.KEY.D;
	
	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Jump")]
	private Input.KEY playerJump = Input.KEY.SPACE;
	
	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Primary Attack Ability")]
	private Input.MOUSE_BUTTON wpnAttack = Input.MOUSE_BUTTON.LEFT;
	
	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Secondary Attack Ability")]
	private Input.MOUSE_BUTTON wpnSecondary = Input.MOUSE_BUTTON.RIGHT;
	
	[ShowInEditor][Parameter(Group = "Controls", Tooltip = "Switch Weapon")]
	private Input.KEY switchWeapon = Input.KEY.DIGIT_1;

	[ShowInEditor]
	[ParameterSlider(Min = 0.0f, Group = "Input", Tooltip = "Mouse sensitivity multiplier")]
	private float mouseSensitivity = 0.4f;

	[ShowInEditor]
	[Parameter(Group = "Settings", Tooltip = "Power of the jump impulse")]
	private float jumpPower = 10000f;

	[ShowInEditor]
	[Parameter(Group = "Camera", Tooltip = "Drag the camera node from the World Nodes hierarchy here")]
	private PlayerDummy camera = null;

	[ShowInEditor]
	[ParameterSlider(Min = -89.9f, Max = 89.9f, Group = "Camera", Tooltip = "The minimum vertical angle of the camera, i.e. maximum possible angle to look down.")]
	private float minVerticalAngle = -89.9f;

	[ShowInEditor]
	[ParameterSlider(Min = -89.9f, Max = 89.9f, Group = "Camera", Tooltip = "The maximum vertical angle of the camera, i.e. maximum possible angle to look up.")]
	private float maxVerticalAngle = 89.9f;

	private float phiAngle = 90.0f;
	private float cameraVerticalAngle = 0.0f;
	private float cameraHorizontalAngle = 0.0f;
	
	private void Init()
	{
	}
	
	private void Controls (){
		float ifps = Game.IFps;
		vec3 up = vec3.UP; //always UP
		vec3 forward = vec3.FORWARD; //always FOREWARD
		vec3 impulse = vec3.ZERO; //default impulse

		// ortho basis
		vec3 tangent, binormal;
		Geometry.OrthoBasis(up, out tangent, out binormal);

		// current basis
		vec3 x = new quat(up, -phiAngle) * binormal;
		vec3 y = MathLib.Normalize(MathLib.Cross(up, x));
		vec3 z = MathLib.Normalize(MathLib.Cross(x, y));

		vec3 foreDirection = node.GetWorldDirection(MathLib.AXIS.Y); //Get forward direction
		vec3 strafeDirection = node.GetWorldDirection(MathLib.AXIS.X); //get left direction
		
		if (Input.IsKeyPressed(forwardMove)){
			node.WorldTranslate(foreDirection * PlayerSpeed * ifps); 
		}
		if (Input.IsKeyPressed(backwardMove)){
			node.WorldTranslate(-foreDirection * PlayerSpeed * ifps);
		}
		if (Input.IsKeyPressed(leftMove)){
			node.WorldTranslate(-strafeDirection * PlayerSpeed * ifps);
		}
		if (Input.IsKeyPressed(rightMove)){
			node.WorldTranslate(strafeDirection * PlayerSpeed * ifps);
		}

		if (App.MouseGrab) //if game in focus
		{
			// change vertical angle of camera
			cameraVerticalAngle -= Input.MouseDelta.y * mouseSensitivity;

			//gather mouse input and set range of vertical camera movement
			float delta = -Input.MouseDelta.y * mouseSensitivity;
			cameraVerticalAngle += delta;
			cameraVerticalAngle = MathLib.Clamp(cameraVerticalAngle, minVerticalAngle + 90.0f, maxVerticalAngle + 90.0f);

			//node and camera horizontal rotation
			node.Rotate(0.0f, 0.0f, (-Input.MouseDelta.x * mouseSensitivity));
			cameraHorizontalAngle += (-Input.MouseDelta.x * mouseSensitivity);
			
		}
		//apply vertical rotation to camera
		vec3 cameraDirection = forward * MathLib.RotateZ(-cameraHorizontalAngle);
		cameraDirection = cameraDirection * MathLib.Rotate(MathLib.Cross(cameraDirection, up), 90.0f - cameraVerticalAngle);
		cameraDirection.Normalize();
		camera.SetWorldDirection(cameraDirection, up);
	}
	private void Update() {
		Controls();

	}

	private void UpdatePhysics(){
	}
}