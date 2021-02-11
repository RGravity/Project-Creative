using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	private void OnTriggerEnter(Collider other)
    {
        print("Something is hitting a Solid Object with tag: " + other.tag);
        if (other.tag == "Player")
        {
            GameObject.FindObjectOfType<BasicPlayerMovement>().CanJumpSetter = true;
            print("Player is hitting a Solid Object");
        }
        else
        {
            // Do something else
        }
    }

}
