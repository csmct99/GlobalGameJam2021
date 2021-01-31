using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] [Header("Referances")]
	private GameObject target;

	[SerializeField] [Header("Referances")]
	private GameObject shootPosition;

	[SerializeField] [Header("AI Settings")]
	private float movementSpeed = 1f;

	[SerializeField] [Header("AI Settings")]
	private float attackDistance = 6f;

	[SerializeField] [Header("AI Settings")]
	private float attackDistanceVariability = 1f;

	[SerializeField] [Header("AI Settings")]
	private float attackCooldown = 3f;
	private float lastAttackTime = -999f;

	[SerializeField] 
	private string bulletPrefab = "Prefabs/Projectile/Gib Projectile.GameObject";

	[SerializeField] [Header("AI Settings")]
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
        
    }

    
}
