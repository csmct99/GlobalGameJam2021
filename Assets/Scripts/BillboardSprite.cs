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
            //Lookat backwards (sprites are backwards for some reason)
            gameObject.transform.LookAt(2 * transform.position - Camera.main.gameObject.transform.position); //Dude ... this shit is so much easier in Unity ...
		}

        
    }
}
