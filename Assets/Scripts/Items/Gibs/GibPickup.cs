using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibPickup : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider collider){
        CharactorController controller = (collider.gameObject.GetComponent<CharactorController>());
        Enemy enemy = (collider.gameObject.GetComponent<Enemy>());

        
    }
}
