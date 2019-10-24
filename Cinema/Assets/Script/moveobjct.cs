using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobjct : MonoBehaviour
{

    Vector3 screenPoint;
    private bool active = true;
    private bool stay;
    public Onground ong;

    // Update is called once per frame
    void Start()
    {

    }

    void Update()
    {

        if (active == true && GoScript.actorIsmoving == false)
        {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120);
            transform.position = Camera.main.ScreenToWorldPoint(a);
            if (Input.GetMouseButton(1))
            {
                string obname;
                obname = transform.name;
                if (obname.StartsWith("Bone") == true)
                {
                    select.BoneN++;
                }
                if (obname.StartsWith("Bridge(") == true)
                {
                    select.BridgeN++;
                }
                if (obname.StartsWith("Rope(") == true)
                {
                    select.RopeN++;
                }
                if (obname.StartsWith("Turuhashi") == true)
                {
                    select.TuruhashiN++;
                }
                if (obname.StartsWith("Fire") == true)
                {
                    select.FireN++;
                }
                if (obname.StartsWith("Banana") == true)
                {
                    select.BananaN++;
                }
                select.isSelected = false;
                Destroy(gameObject);
            }
            if (Input.GetMouseButtonUp(0) && select.isSelected == true)
            {
                string obname;
                obname = this.gameObject.name;
                if (obname.StartsWith("Rope(") == true)
                {
                    if (transform.position.x > 19.5f && transform.position.x < 21.0f)
                    {
                        active = false;
                        select.isSelected = false;
                        transform.position = new Vector3(20.31415f, 3.905f, 100f);
                    }
                    else if (transform.position.x > 49.5f && transform.position.x < 51.0f)
                    {
                        active = false;
                        select.isSelected = false;
                        transform.position = new Vector3(50.0f, 3.905f, 100f);
                    }
                }
                else if (obname.StartsWith("Bridge(") == true && transform.position.x > 19.0f && transform.position.x < 22.0f
                    && transform.position.y > -1f && transform.position.y < 1.0f)
                {
                    active = false;
                    select.isSelected = false;
                    transform.position = new Vector3(20.9f, -0.93f, 100f);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        stay = true;
    }

    void OnCollisionStay(Collision other)
    {
        stay = true;
    }

    void OnCollisionExit(Collision other)
    {
        stay = false;
    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButton(0) && GoScript.actorIsmoving == false)
        {
            string obname;
            obname = this.gameObject.name;
            if (obname.StartsWith("Bone") == true)
            {

                if (stay == false && active == true && select.isSelected == true && ong.stayg == true)
                {
                    active = false;
                    select.isSelected = false;
                }
                else if (active == false)
                {
                    active = true;
                    select.isSelected = true;

                }
            }
            else if (obname.StartsWith("Turuhashi") == true)
            {
                if (stay == false && active == true && select.isSelected == true && ong.stayg == true)
                {
                    active = false;
                    select.isSelected = false;
                }
                else if (active == false)
                {
                    active = true;
                    select.isSelected = true;
                }
            }
            else if (obname.StartsWith("Banana") == true)
            {
                if (stay == false && active == true && select.isSelected == true && ong.stayg == true)
                {
                    active = false;
                    select.isSelected = false;
                }
                else if (active == false)
                {
                    active = true;
                    select.isSelected = true;
                }
            }
            else if (obname.StartsWith("Fire") == true)
            {
                if (stay == false && active == true && select.isSelected == true)
                {
                    ActorController.fx = this.gameObject.transform.position.x;
                    ActorController.fy = this.gameObject.transform.position.y;
                    ActorController.fz = this.gameObject.transform.position.z;
                    active = false;
                    select.isSelected = false;
                }
                else if (active == false)
                {
                    active = true;
                    select.isSelected = true;
                }
            }
            else if (obname.StartsWith("Bridge(") == true)
            {
                if (active == false && select.isSelected == false)
                {
                    active = true;
                    select.isSelected = true;
                }

            }
            else if (obname.StartsWith("Rope(") == true)
            {
                if (active == false && select.isSelected == false)
                {
                    active = true;
                    select.isSelected = true;
                }
            }
        }
    }
}


