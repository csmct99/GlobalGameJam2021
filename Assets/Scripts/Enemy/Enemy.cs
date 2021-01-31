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
	private string bulletPrefab = "Prefabs/Projectile/Gib Projectile.GameObject";

	[SerializeField]
	private float agentRadius = 0.5f;


	[SerializeField] [Header("Settings")]
	private bool DEBUG = true;
	
	[SerializeField]
	private int maxHealth = 10;
	private int health;

	


    void Start() {
        health = maxHealth;
    }

    void Update() {
        if(Mathf.Abs((target.position - transform.position).magnitude) > 6){
			agent.SetDestination(target.position);
			agent.isStopped = false;
		}else{
			print("Close enough, done");
			agent.isStopped = true;
		}
    }

    
}
