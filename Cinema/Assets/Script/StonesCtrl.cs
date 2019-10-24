using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesCtrl : MonoBehaviour {
    public static bool stonesCrash = false;
    private float count;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire" && GoScript.actorIsmoving == true) 
        {
            
            stonesCrash = true;
        }
    }
    // Update is called once per frame
    void Update () {
        //Debug.Log(count);
        GameObject[] stones = GameObject.FindGameObjectsWithTag("stone");
        if (stonesCrash == true)
        {
            count += Time.deltaTime;
            if (count > 0 && count <= 3.0f)
            {
                foreach (GameObject obj in stones)
                {
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.None;
                }
            }
            else if (count > 3.0f)
            {
                foreach (GameObject obj in stones)
                {
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezePositionY;
                }
                count = 0;
                stonesCrash = false;
            }
        }
        
	}
}
