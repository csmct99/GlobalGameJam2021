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

	[SerializeField]
	protected GameObject gibPrefab;

	[SerializeField] [Header("AI Settings")]
	protected float movementSpeed = 1f;

	[SerializeField]
	private float takeDamageCooldown = 0.1f;
	private float lastDamageTaken = -99f;

	[SerializeField]
	protected float attackCooldown = 3f;
	protected float lastAttackTime = -999f;

	[Header("Settings")]
	[SerializeField] 
	protected int numberOfGibsOnDeath = 4;

	[SerializeField] 
	protected float gibExplosiveForce = 100f;

	[SerializeField]
	protected int maxHealth = 10;
	protected int health;
	protected bool isDead = false;
	protected bool isDeadFirst = true;

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

	public void TakeDamage(int damage){
		//print(name + " took damage " + damage);
		if(Time.time - lastDamageTaken > takeDamageCooldown){
			lastDamageTaken = Time.time;
			health -= damage;
			if(health < 1 && isDeadFirst){
				Die();
			}
		}
	}

	protected virtual void Die(){
		isDead = true;
		isDeadFirst = false;

		for(int i = 1; i <= numberOfGibsOnDeath; i++){
			GameObject gib = Instantiate(gibPrefab);
			gib.name = "gib " + i;
			gib.transform.position = transform.position + transform.forward;
			gib.GetComponent<Rigidbody>().AddExplosionForce(gibExplosiveForce, gameObject.transform.position, 3f, gibExplosiveForce/10, ForceMode.Impulse);
		}
	}
    
}
