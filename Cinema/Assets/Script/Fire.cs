using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public static float count;
    private bool countup = false;
    public Rigidbody rb;
    public bool IsUsed;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"&&GoScript.actorIsmoving == true)
        {
            GoScript.actorIsfiring = true;
            countup = true;
            IsUsed = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update () {
        if(countup == true)
        {
            count += Time.deltaTime;
        }
        if (count >= 1.0f && count <2.5f)
        {
            rb.velocity = new Vector3(4.0f, 2.5f, 0);
            rb.useGravity = true;
        }
        else if(count >= 3.0f)
        {
            this.gameObject.transform.Translate(new Vector3 (-3000, 0, 0));
            rb.constraints = RigidbodyConstraints.FreezeAll;
            GoScript.actorIsfiring = false;
            countup = false;
            count = 0;
            rb.useGravity = false;
        }
	}
}
