using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maguma : MonoBehaviour {
    public bool IsDestroy;
    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stone" && IsDestroy == false)
        {
            this.transform.Translate(new Vector3(0, 300.0f, 0));
            IsDestroy = true;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
