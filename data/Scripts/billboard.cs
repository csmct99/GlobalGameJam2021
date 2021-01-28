using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "c3704569ac0b4fb44357b78386cc77062bd362ad")]
public class billboard : Component {

	public PlayerActor target;
	public vec3 upDirection = vec3.DOWN;

	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update() {
		if(target != null){
			vec3 direction = new vec3(target.Camera.Position - node.WorldPosition).Normalize();
   			node.SetDirection(-direction, upDirection);
			   
		}
	}
}