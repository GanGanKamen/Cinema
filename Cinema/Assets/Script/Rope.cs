using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
    private Animator anmRope;
	// Use this for initialization
	void Start () {
		anmRope = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(ActorController.ropeAction == true)
        {
            anmRope.SetBool("action", true);
        }
        else
        {
            anmRope.SetBool("action", false);
        }
	}
}
