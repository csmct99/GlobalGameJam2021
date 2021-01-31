using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable {

    [SerializeField] [Header("Referances")]
	protected Transform target;

	[SerializeField]
	protected NavMeshAgent agent;

	[SerializeField]
	protected AudioSource audioSource;

	[SerializeField] [Header("AI Settings")]
	protected float movementSpeed = 1f;

	[SerializeField]
	protected float attackCooldown = 3f;
	protected float lastAttackTime = -999f;

	[Header("Settings")]
	[SerializeField]
	protected int maxHealth = 10;
	protected int health;
	protected bool isDead = false;

	[SerializeField]
	protected LayerMask layersToBreakLOS = -1;


    void Start() {
        health = maxHealth;
    }

    void Update() {
		agent.isStopped = true; //Set to true every frame (Will be overridden if needed)

		if(!isDead) Logic();
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


	public virtual void TakeDamage(int damage){
		health -= damage;
		if(health < 1){
			Die();
		}
	}

	protected virtual void Die(){
		isDead = true;
	}
    
}
