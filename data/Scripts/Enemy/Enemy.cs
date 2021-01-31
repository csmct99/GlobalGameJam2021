using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "9420cacea10553d5b8e81330f78d0ccf41ea13e2")]
public class Enemy : Component {

	[ShowInEditor] [Parameter(Group = "Referances")]
	private Node target;

	[ShowInEditor] [Parameter(Group = "Referances")]
	private Node shootPosition;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float movementSpeed = 1f;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float attackDistance = 6f;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float attackDistanceVariability = 1f;

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float attackCooldown = 3f;
	private float lastAttackTime = -999f;

	[ShowInEditor] 
	private string bulletPrefab = "Prefabs/Projectile/Gib Projectile.node";

	[ShowInEditor] [Parameter(Group = "AI Settings")]
	private float agentRadius = 0.5f;

	[ShowInEditor] [Parameter(Group = "Settings")]
	private bool DEBUG = true;

	private PathRoute route;
	
	[ShowInEditor]
	private int maxHealth = 10;
	private int health;

	private WorldIntersection intersection;

	private void Init() {
		health = maxHealth;

		route = new PathRoute();
		route.Radius = agentRadius;

		Visualizer.Enabled = true;

		intersection = new WorldIntersection();
	}
	
	private void Update() {
		PathfindingLogic();

	}


	protected virtual void PathfindingLogic(){
		if(DEBUG){
			Visualizer.RenderCircle(agentRadius, new mat4(quat.IDENTITY, node.WorldPosition), vec4.YELLOW);
			Visualizer.RenderCircle(attackDistance - attackDistanceVariability, new mat4(quat.IDENTITY, target.WorldPosition), vec4.RED); //Min dist
			Visualizer.RenderCircle(attackDistance, new mat4(quat.IDENTITY, target.WorldPosition), vec4.GREEN); //Ideal dist
			Visualizer.RenderCircle(attackDistance + attackDistanceVariability, new mat4(quat.IDENTITY, target.WorldPosition), vec4.RED); //Max dist
		}
		
		float distance = Math.Abs((node.WorldPosition - target.WorldPosition).Length);
		if(distance > attackDistance + attackDistanceVariability){ // IS not in range +- variability range // || distance < attackDistance - attackDistanceVariability 
			Move();//Move to target
			if(DEBUG) Log.MessageLine("Trying to get closer to target");

		} else { // Is in an ideal range
			if(DEBUG){
				Log.MessageLine("Ideal range logic");
				Visualizer.RenderLine3D(shootPosition.WorldPosition, target.WorldPosition, vec4.BLUE);
			}

			List<Unigine.Object> objects = new List<Unigine.Object>(); //List of objects hit by intersection
			World.GetIntersection(shootPosition.WorldPosition, target.WorldPosition, objects); //Line from gun to target
			
			bool invalidTargetFound = false;
			foreach(Unigine.Object o in objects){ //For every object collided with
				Node n = o as Node;

				if(n.Equals(target) || n.Equals(node) || n.GetComponent<Enemy>() != null){ //If the thing on the shoot path is the target or this enemy, that is fine
					continue;
				}else{ // Something is in the way
					invalidTargetFound = true;
					break;
				}
			}

			if(!invalidTargetFound){
				if(DEBUG) Log.MessageLine("Shoot that mofo");
				Attack();

			}else{
				Move(); //Move to target
				if(DEBUG) Log.MessageLine("Cant see - Moving null target");
			}
		}
	}

	protected virtual void Attack(){
		if(Game.Time - lastAttackTime > attackCooldown){ // Can attack
			lastAttackTime = Game.Time;
			Node projectile = World.LoadNode(bulletPrefab);
			projectile.WorldPosition = shootPosition.WorldPosition;
			projectile.SetWorldDirection((shootPosition.WorldPosition - target.WorldPosition).Normalize(), vec3.UP);
			if(DEBUG) Visualizer.RenderVector(node.WorldPosition, (shootPosition.WorldPosition - target.WorldPosition).Normalize(), vec4.RED);


		}
	}

	protected virtual void Move(){
			route.Create2D(node.WorldPosition, target.WorldPosition); //Calc a new path to the target

			if(route.NumPoints > 1) {
				vec3 point = route.GetPoint(1);
				point.z = node.WorldPosition.z;

				vec3 direction = (point - node.WorldPosition).Normalize();
				
				node.WorldTranslate(direction * movementSpeed * Game.IFps);
				if(DEBUG) route.RenderVisualizer(vec4.RED);
				

			}
	}
}

