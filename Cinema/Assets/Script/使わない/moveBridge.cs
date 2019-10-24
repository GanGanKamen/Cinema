using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBridge : MonoBehaviour
{
    Vector3 screenPoint;
    private bool active = true;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120);
            transform.position = Camera.main.ScreenToWorldPoint(a);
            if (Input.GetMouseButton(1))
            {
                string obname;
                obname = transform.name;
                Debug.Log(obname);
                if (obname.StartsWith("Bone") == true)
                {
                    select.BoneN++;
                }
                if (obname.StartsWith("Bridge") == true)
                {
                    select.BridgeN++;
                }

                Destroy(gameObject);
            }
            else if (Input.GetMouseButton(0))
            {
                string obname;
                obname = transform.name;
                if (obname.StartsWith("Bridge") == true && transform.position.x > 19.0f && transform.position.x < 21.0f)
                {
                    Debug.Log("Ok");
                    active = false;
                    gameObject.transform.position = new Vector3(20.9f,-0.78f, 100f);
                    
                }
            }
        }
    }
}
