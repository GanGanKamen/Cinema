using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour {
    public bool isBreak = false;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player"&& ActorController.picksCount >0)
        {
            //ActorController.picksCount--;
            this.gameObject.transform.Translate(new Vector3 (-3000, 0, 0));
            isBreak = true;
            ActorController.ActionP += 500;
        }
    }
}
