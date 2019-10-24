using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLadder : MonoBehaviour
{
    Vector3 screenPoint;
    public bool active = true;
    private bool stay;
    Vector3 position;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
        if (active == true)
        {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 119);
            transform.position = Camera.main.ScreenToWorldPoint(a);

            if (position.x >= 26.0f && position.x <= 48.0f
           && position.y >= 0.6f && position.y <= 3.0f)
            {
                stay = true;
            }
            else
            {
                stay = false;
            }

            if (Input.GetMouseButton(1))
            {
                string obname;
                obname = transform.name;
                if (obname.StartsWith("Ladder") == true)
                {
                    select.LadderN++;
                }
                select.isSelected = false;
                Destroy(gameObject);
            }
            if (Input.GetMouseButtonUp(0))
            {
                string obname;
                obname = this.gameObject.name;
                if (obname.StartsWith("Ladder") == true)
                {
                    if (stay == true && active == true)
                    {
                        active = false;
                        transform.position = new Vector3(this.transform.position.x, 2.3f, this.transform.position.z);
                        select.isSelected = false;
                    }
                    /*else if (active == false)
                    {
                        active = true;
                        select.isSelected = true;
                    }
                    */
                }
            }

        }
        
    }

    private void OnMouseDown()
    {
        if (active == false && select.isSelected == false&& GoScript.actorIsmoving == false)
        {
            active = true;
            select.isSelected = true;
        }
    }

}