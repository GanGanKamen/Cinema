using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject Rope, window, retake;
    static public int picksCount = 0;
    static public bool isClimbing = false;
    static public int retakeCount = 0;
    static public int ActionP, ObjectP;
    private float jumpPower = 7f;
    private float bananaJump = 5f;
    private float bananaDash = 0.2f;
    private float count01 = 0;
    static public float fx, fy, fz;
    static public bool ropeAction = false;
    //static public bool isOnRope;
    private Animator anmActor;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anmActor = GetComponent<Animator>();
        //isOnRope = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GoScript.actorIsmoving == true&&collision.gameObject.tag == "PutObject"||collision.gameObject.tag == "Picks"|| collision.gameObject.tag == "Firestone")
        {
            ObjectP += 100;
            if (collision.gameObject.name.StartsWith("Bridge")) ActionP += 500;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "RopeEvent")
        {
            rb.velocity = Vector3.up * jumpPower;
            anmActor.SetBool("jump", true);
        }
        if (collision.gameObject.tag == "LadderEvent" && GoScript.actorIsmoving == true)
        {
            isClimbing = true;
            if (GoScript.actorIsmoving == true) ActionP += 500;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                this.transform.position.z - 2.0f);
            rb.useGravity = false;
        }
        if (collision.gameObject.tag == "Rope")
        {
            //isOnRope = true;
            if (GoScript.actorIsmoving == true)ActionP += 1000;
            rb.velocity = Vector3.up * jumpPower * 2/3;
            anmActor.SetBool("jump_over", true);
            ropeAction = true;
        }
        if(collision.gameObject.tag == "Banana")
        {
            rb.velocity = new Vector3(1.0f * bananaDash, 1.0f * bananaJump, 0) ;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Check01")
        {
            CameraCtrl.posX = 45.0f;
        }
        if (collision.gameObject.tag == "Goal")
        {
            GoScript.actorIsmoving = false;
        }
        if (collision.gameObject.tag == "LadderEvent")
        {
            isClimbing = false;
            this.transform.position = new Vector3(this.transform.position.x,
                this.transform.position.y + 1.0f, this.transform.position.z + 2.0f);
            rb.useGravity = true;
            rb.velocity = Vector3.up * 1.0f;
        }
        if (collision.gameObject.tag == "Rope")
        {
            count01 = 0;
            //isOnRope = false;
            anmActor.SetBool("jump", false);
            anmActor.SetBool("jump_over", false);
            ropeAction = false;

        }

    }

    private void OnTriggerStay(Collider collision)
    {

        /*if (collision.gameObject.tag == "Rope")
        {
            count01 += Time.deltaTime;
            if (count01 >= 0 && count01 <= 1.5)
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
                //GoScript.actorIsmoving = false;
            }
            else if (count01 > 1.5)
            {
                //GoScript.actorIsmoving = true;
                rb.useGravity = true;
            }
        }*/
        if (collision.gameObject.tag == "LadderEvent"&&GoScript.actorIsmoving == true)
        {
            this.transform.position += this.transform.up * 0.08f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ActionP);
        //Debug.Log(isOnRope);
        if(GoScript.actorIsmoving == true)
        {
            anmActor.SetBool("dash", true);
            /*if(isOnRope == true)
            {
                anmActor.SetBool("jump_over", true);
            }
            else if (isOnRope == false)
            {
                anmActor.SetBool("jump_over", false);
            }*/
            if(Fire.count > 0 && Fire.count < 1.0f)
            {
                anmActor.SetBool("pick_up", true);
            }
            if(Fire.count >= 0.6f)
            {
                anmActor.SetBool("throw", true);
            }
            if(Fire.count >= 2.5f)
            {
                anmActor.SetBool("pick_up", false);
            }
        }
        else
        {
            anmActor.SetBool("dash", false);
        }

    }
    public void ReTake()
    {
        anmActor.SetBool("retake", true);
        anmActor.SetBool("jump", false);
        anmActor.SetBool("pick_up", false);
        anmActor.SetBool("jump_over", false);
        ropeAction = false;
        int Scount = 0;
        isClimbing = false;
        rb.useGravity = true;
        count01 = 0;
        //isOnRope = false;
        GoScript.actorIsmoving = false;
        GoScript.actorIsfiring = false;
        window.SetActive(true);
        picksCount = 0;
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject obj in rocks)
        {
            if (obj.GetComponent<Rock>().isBreak == true)
            {
                obj.gameObject.transform.Translate(new Vector3(3000, 0, 0));
                obj.GetComponent<Rock>().isBreak = false;
            }
        }
        this.transform.position = new Vector3(7, 0, 100);
        retake.SetActive(false);
        select.isSelected = false;
        StonesCtrl.stonesCrash = false;
        if (select.FireN == 0)
        {
            GameObject[] fire = GameObject.FindGameObjectsWithTag("Firestone");
            if (fire[0].GetComponent<Fire>().IsUsed == true)
            {

                fire[0].transform.position = new Vector3(fx, fy, fz);
                fire[0].GetComponent<Fire>().IsUsed = false;
            }
        }
        /*
        select.BoneN = 5;
        select.BridgeN = 1;
        select.RopeN = 1;
        select.TuruhashiN = 1;
        select.LadderN = 2;
        select.FireN = 1;
        GameObject[] Puts = GameObject.FindGameObjectsWithTag("PutObject");
        foreach (GameObject obj in Puts)
        {
            Destroy(obj);
        }
        */
        ActionP = 0;
        ObjectP = 0;
        GameObject[] stones = GameObject.FindGameObjectsWithTag("stone");
        foreach (GameObject obj in stones)
        {

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            if (Scount == 0)
            {
                obj.gameObject.transform.localPosition = new Vector3(-1.04f, 0.52f, 0);
                obj.gameObject.transform.Rotate(new Vector3(0, 60, 0));
            }
            else if (Scount == 1)
            {
                obj.gameObject.transform.localPosition = new Vector3(0.03000473f, 0.52f, -0.7100028f);
                obj.gameObject.transform.Rotate(new Vector3(-48.906f, 100, 0));
            }
            else if (Scount == 2)
            {
                obj.gameObject.transform.localPosition = new Vector3(1.18f, 0.52f, 0);
                obj.gameObject.transform.Rotate(new Vector3(40, 20, 5));
            }
            else if (Scount == 3)
            {
                obj.gameObject.transform.localPosition = new Vector3(2.279999f, 0.5900002f, 0);
                obj.gameObject.transform.Rotate(new Vector3(3.3f, 100, -20.52f));
            }
            Scount++;
        }

        GameObject[] pic = GameObject.FindGameObjectsWithTag("Picks");
        foreach (GameObject obj in pic)
        {
            if (obj.GetComponent<Picks>().Isused == true)
            {
                obj.gameObject.transform.Translate(new Vector3(3000, 0, 0));
                obj.GetComponent<Picks>().Isused = false;
            }
        }
        GameObject[] lava = GameObject.FindGameObjectsWithTag("Lava");
        foreach (GameObject obj in lava)
        {
            if (obj.GetComponent<Maguma>().IsDestroy == true)
            {
                obj.gameObject.transform.Translate(new Vector3(0, -300, 0));
                obj.GetComponent<Maguma>().IsDestroy = false;
            }
        }
        CameraCtrl.posX = 20.0f;
        retakeCount++;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }


    public void RePlay()
    {
        int Scount = 0;
        isClimbing = false;
        rb.useGravity = true;
        count01 = 0;
        //isOnRope = false;
        GoScript.actorIsmoving = false;
        GoScript.actorIsfiring = false;
        window.SetActive(true);
        picksCount = 0;
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject obj in rocks)
        {
            if (obj.GetComponent<Rock>().isBreak == true)
            {
                obj.gameObject.transform.Translate(new Vector3(3000, 0, 0));
                obj.GetComponent<Rock>().isBreak = false;
            }
        }
        this.transform.position = new Vector3(7, 0, 100);
        retake.SetActive(false);
        select.isSelected = false;
        StonesCtrl.stonesCrash = false;
        select.BoneN = 5;
        select.BridgeN = 1;
        select.RopeN = 1;
        select.TuruhashiN = 1;
        select.LadderN = 2;
        select.FireN = 1;
        GameObject[] Puts = GameObject.FindGameObjectsWithTag("PutObject");
        foreach (GameObject obj in Puts)
        {
            Destroy(obj);
        }
        GameObject[] fire = GameObject.FindGameObjectsWithTag("Firestone");
        foreach (GameObject obj in fire)
        {
            Destroy(obj);
        }
        GameObject[] pic = GameObject.FindGameObjectsWithTag("Picks");
        foreach (GameObject obj in pic)
        {
            Destroy(obj);
        }
        ActionP = 0;
        ObjectP = 0;
        GameObject[] stones = GameObject.FindGameObjectsWithTag("stone");
        foreach (GameObject obj in stones)
        {

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            if (Scount == 0)
            {
                obj.gameObject.transform.localPosition = new Vector3(-1.04f, 0.52f, 0);
                obj.gameObject.transform.Rotate(new Vector3(0, 60, 0));
            }
            else if (Scount == 1)
            {
                obj.gameObject.transform.localPosition = new Vector3(0.03000473f, 0.52f, -0.7100028f);
                obj.gameObject.transform.Rotate(new Vector3(-48.906f, 100, 0));
            }
            else if (Scount == 2)
            {
                obj.gameObject.transform.localPosition = new Vector3(1.18f, 0.52f, 0);
                obj.gameObject.transform.Rotate(new Vector3(40, 20, 5));
            }
            else if (Scount == 3)
            {
                obj.gameObject.transform.localPosition = new Vector3(2.279999f, 0.5900002f, 0);
                obj.gameObject.transform.Rotate(new Vector3(3.3f, 100, -20.52f));
            }
            Scount++;
        }


        GameObject[] lava = GameObject.FindGameObjectsWithTag("Lava");
        foreach (GameObject obj in lava)
        {
            if (obj.GetComponent<Maguma>().IsDestroy == true)
            {
                obj.gameObject.transform.Translate(new Vector3(0, -300, 0));
                obj.GetComponent<Maguma>().IsDestroy = false;
            }
        }
        CameraCtrl.posX = 20.0f;
        retakeCount =0;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
