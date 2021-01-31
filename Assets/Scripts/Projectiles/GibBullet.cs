using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibBullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 100f;

    [SerializeField]
    private int damage = 3;

    [SerializeField]
    private float maxLifetime = 30f;

    private float birthTime = 0f;

    [SerializeField]
    private LayerMask layersToBreakProjectile = 0;

    // Start is called before the first frame update
    void Start(){
        birthTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if(Time.time - birthTime > maxLifetime){ //Too old to live ...
            Destroy(gameObject); //kms
        }else{
            
            RaycastHit ray;
			bool hit = Physics.Raycast(transform.position, transform.forward, out ray,  (transform.forward * speed * Time.deltaTime).magnitude, layersToBreakProjectile);

            if(hit){ // If there is something that is no excluded by the mask
                destroyGib();
            }

            gameObject.transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider collider){
        IDamageable d = collider.gameObject.GetComponent<IDamageable>();
        print(collider.gameObject.name);
        if(d != null){
            d.TakeDamage(damage);
        }

        destroyGib();
    }

    private void destroyGib(){
        //TODO: animation here
        Destroy(gameObject);
    }
}
