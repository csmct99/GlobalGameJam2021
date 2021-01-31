using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour {
    
    void Start() {
        if(Camera.main == null){
            Debug.LogError("Cannot find the main camera to billboard to!");
        }
    }

    void Update() {
		if(Camera.main != null){
            gameObject.transform.LookAt(Camera.main.gameObject.transform.position); //Dude ... this shit is so much easier in Unity ...
		}

        
    }
}
