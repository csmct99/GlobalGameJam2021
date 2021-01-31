using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField] [Header("Referances")]
	private Transform target;

	[SerializeField]
	private NavMeshAgent agent;

	[SerializeField]
	private GameObject shootPosition;


	[SerializeField] [Header("AI Settings")]
	private float movementSpeed = 1f;

	[SerializeField] 
	private float attackDistance = 6f;

	[SerializeField]
	private float attackDistanceVariability = 1f;

	[SerializeField]
	private float attackCooldown = 3f;
	private float lastAttackTime = -999f;

	[SerializeField] 
	private GameObject bulletPrefab;

	[SerializeField]
	private float agentRadius = 0.5f;


	[SerializeField] [Header("Settings")]
	private bool DEBUG = true;
	
	[SerializeField]
	private int maxHealth = 10;
	private int health;

	
	public LayerMask attackMask = -1;


    void Start() {
        health = maxHealth;
    }

    void Update() {
		agent.isStopped = true; //Set to true every frame (Will be overridden if needed)

        if(Mathf.Abs((target.position - transform.position).magnitude) < attackDistance){ // In range
			RaycastHit ray;
			bool hit = Physics.Raycast(shootPosition.transform.position, (target.position - shootPosition.transform.position).normalized,  out ray, 999f, attackMask);

			if(hit){ // Hit something
				if(ray.collider.gameObject.CompareTag("Player")){ //Hit player
					Attack();
				}else{
					MoveToTarget();
				}
			}else{
				MoveToTarget();
			}

		}else{ //Not in range
			MoveToTarget();
		}
    }

	private void MoveToTarget(){
			agent.SetDestination(target.position);
			agent.isStopped = false;
	}

	private void Attack(){
		if(Time.time - lastAttackTime > attackCooldown){
			lastAttackTime = Time.time;

			print("Firing!");

			GameObject projectile = Instantiate(bulletPrefab);
			projectile.name = "Bullet (" + Time.time + ")";
			projectile.transform.position = shootPosition.transform.position;
			projectile.transform.LookAt(target.transform.position);


		}
	}

    
}
