using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onground : MonoBehaviour {

    public bool stayg;

    private void OnCollisionEnter(Collision other)
    {
        stayg = true;
    }

    void OnCollisionStay(Collision other)
    {
        stayg = true;
    }

    void OnCollisionExit(Collision other)
    {
        stayg = false;
    }

}


