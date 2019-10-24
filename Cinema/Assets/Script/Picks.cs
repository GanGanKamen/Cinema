using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picks : MonoBehaviour {
    public bool Isused;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player"&& GoScript.actorIsmoving == true)
        {
            ActorController.picksCount++;
            this.gameObject.transform.Translate(new Vector3(-3000, 0, 0));
            Isused = true;
        }
    }

}
