using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAI : Enemy {

    [Header("Rabbit Specific")]
    
    [SerializeField] 
	private GameObject bulletPrefab;

    [SerializeField]
	private GameObject shootPosition;

    [SerializeField] 
	private float attackDistance = 6f;

	[SerializeField]
	private float attackDistanceVariability = 1f;

	[Header("Rabbit Animations")]

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite idleSprite;

	[SerializeField]
	private Sprite reloadingSprite;

	[SerializeField]
	private Sprite aimSprite;


    protected override void Logic(){
		//print("Logic");
        base.Logic();

		if(Mathf.Abs((target.position - transform.position).magnitude) < attackDistance){ // In range
			RaycastHit ray;
			bool hit = Physics.Raycast(shootPosition.transform.position, (target.position - shootPosition.transform.position).normalized,  out ray, 999f, layersToBreakLOS);

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

    protected override void MoveToTarget(){
        base.MoveToTarget();
    }

    protected override void Attack(){
        base.Attack();

        if(Time.time - lastAttackTime > attackCooldown){
			lastAttackTime = Time.time;

			print("Firing!");

			GameObject projectile = Instantiate(bulletPrefab);
			projectile.name = "Bullet (" + Time.time + ")";
			projectile.transform.position = shootPosition.transform.position;
			projectile.transform.LookAt(target.transform.position);


		}else{

		}

    }
}
