using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField] [Header("Referances")]
	protected Transform target;

	[SerializeField]
	protected NavMeshAgent agent;

	[SerializeField] [Header("AI Settings")]
	protected float movementSpeed = 1f;

	[SerializeField]
	protected float attackCooldown = 3f;
	protected float lastAttackTime = -999f;

	[SerializeField] [Header("Settings")]
	protected bool DEBUG = true;
	
	[SerializeField]
	protected int maxHealth = 10;
	protected int health;

	[SerializeField]
	protected Animator animator;


	public LayerMask layersToBreakLOS = -1;


    void Start() {
        health = maxHealth;
    }

    void Update() {
		agent.isStopped = true; //Set to true every frame (Will be overridden if needed)

		Logic();
    }

	protected virtual void Logic(){
		//print("Parent Logic");
	}

	protected virtual void MoveToTarget(){
			agent.SetDestination(target.position);
			agent.isStopped = false;
	}

	protected virtual void Attack(){

	}

    
}
