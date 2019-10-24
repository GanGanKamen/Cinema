using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * 0.05f;
        }
        else if (Input.GetKey("left"))
        {
            transform.position += transform.right * -0.05f;
        }
    }
}
