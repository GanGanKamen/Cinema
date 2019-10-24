using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {
    public GameObject Retakebutton,Scoreboard,Action,Object,Retake,Total,window;
    private int retakeP,totalP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            GoScript.actorIsmoving = false;
            Retakebutton.SetActive(false);
            Scoreboard.SetActive(true);
            if (ActorController.retakeCount > 10)
            {
                retakeP = 0;
            }
            else
            {
                retakeP = (10000 - ActorController.retakeCount * 1000);
            }
            totalP = ActorController.ActionP + retakeP + ActorController.ObjectP;
            Action.GetComponent<Text>().text = ""+ActorController.ActionP;
            Retake.GetComponent<Text>().text = ""+retakeP;
            Object.GetComponent<Text>().text = "" + ActorController.ObjectP;
            Total.GetComponent<Text>().text = "" + totalP;

            

        } 
    }
    public void RePlay()
    {
        window.SetActive(true);
        Scoreboard.SetActive(false);
        GameObject pl = GameObject.FindWithTag("Player");
        pl.GetComponent<ActorController>().RePlay();
    }
}
