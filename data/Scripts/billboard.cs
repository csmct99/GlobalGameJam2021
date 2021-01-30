using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "c3704569ac0b4fb44357b78386cc77062bd362ad")]
public class billboard : Component {

	public Node target;
	private Camera camera;
	public vec3 upDirection = vec3.UP;

	private void Init()
	{
		camera = Game.Player.Camera ;

		if(camera == null){
			if(target == null){
				Log.FatalLine("Billboard : No target set and no main camera set");
			}
		}
	}
	
	private void Update() {
		vec3 direction;

		Log.MessageLine(camera.ToString());

		if(camera != null){
			direction = new vec3(camera.Position - node.WorldPosition).Normalize();
		}else{
			direction = new vec3(target.WorldPosition - node.WorldPosition).Normalize();
		}

		node.SetDirection(-direction, upDirection);
	}
}