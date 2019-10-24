using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" )
        {
            other.gameObject.GetComponent<ActorController>().ReTake();
        }
    }
}
