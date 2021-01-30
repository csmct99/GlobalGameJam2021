using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "9420cacea10553d5b8e81330f78d0ccf41ea13e2")]
public class Enemy : Component {

	public Node target;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float movementSpeed = 1f;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float attackDistance = 6f;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float attackDistanceVariability = 1f;

	[ShowInEditor] [Parameter(Group = "Settings")]
	private bool DEBUG = true;

	private PathRoute route;
	
	[ShowInEditor]
	private int maxHealth = 10;
	private int health;

	private void Init() {

		health = maxHealth;


		route = new PathRoute();
		route.Radius = 0.25f;

		Visualizer.Enabled = true;
	}
	
	private void Update() {
		PathfindingLogic();

	}

	


	private void PathfindingLogic(){
		if(DEBUG){
			Visualizer.RenderCircle(attackDistance - attackDistanceVariability, new mat4(quat.IDENTITY, target.WorldPosition), vec4.RED); //Min dist
			Visualizer.RenderCircle(attackDistance, new mat4(quat.IDENTITY, target.WorldPosition), vec4.GREEN); //Ideal dist
			Visualizer.RenderCircle(attackDistance + attackDistanceVariability, new mat4(quat.IDENTITY, target.WorldPosition), vec4.RED); //Max dist
		}
		
		float distance = Math.Abs((node.WorldPosition - target.WorldPosition).Length);
		if(distance > attackDistance + attackDistanceVariability || distance < attackDistance - attackDistanceVariability ){ // IS not in range +- variability range
			route.Create2D(node.WorldPosition, target.WorldPosition); //Calc a new path to the target

			if(route.NumPoints > 1) {
				vec3 point = route.GetPoint(1);
				point.z = node.WorldPosition.z;

				vec3 direction = (point - node.WorldPosition).Normalize();
				
				node.WorldTranslate(direction * movementSpeed * Game.IFps);
				if(DEBUG) route.RenderVisualizer(vec4.RED);
				

			}
		} else { // Strafe the target



		}
	}
}

