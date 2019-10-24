using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoScript : MonoBehaviour {
    public GameObject window,retake;
    public GameObject actor;
    public Rigidbody rb;
    public Animator anmActor;
    public static bool actorIsmoving;
    public static bool actorIsfiring;
    Rigidbody actorRi;
    // Use this for initialization
    void Start()
    {
        actorIsfiring = false;
        actorIsmoving = false;
        actorRi = actor.GetComponent<Rigidbody>();
    }

    public void OnClick()
    {
        rb = GetComponent<Rigidbody>();
        window.SetActive(false);
        actorIsmoving = true;
        actorRi.constraints = RigidbodyConstraints.None;
        actorRi.constraints = RigidbodyConstraints.FreezeRotation;
        CameraCtrl.posX = 20.0f;
        retake.SetActive(true);
        anmActor.SetBool("retake", false);

    }

    void Update()
    {
        if(actorIsmoving == true && ActorController.isClimbing == false && 
            actorIsfiring == false /*&& ActorController.isOnRope == false*/)
        {
            actor.transform.position += actor.transform.forward * 0.09f;

        }

    }
}
