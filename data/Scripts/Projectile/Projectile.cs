using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "c5210518e67bc5978d31260ab40fdde15e9dddcc")]
public class Projectile : Component {

	[ShowInEditor][Parameter(Group = "Settings")] 
	private bool DEBUG = false;

	[ShowInEditor][Parameter(Group = "Settings")] 
	private float speed = 1f;

	private void Init() {
		Visualizer.Enabled = true;
		
	}
	
	private void Update() {
		vec3 direction = node.GetWorldDirection(MathLib.AXIS.Z).Normalize();
		node.WorldTranslate( direction * speed * Game.IFps);
		if(DEBUG) Visualizer.RenderVector(node.WorldPosition, node.WorldPosition + direction, vec4.RED);
	}
}