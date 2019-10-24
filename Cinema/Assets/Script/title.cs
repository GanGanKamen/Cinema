using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour {
    public GameObject Logo,button,window,Maincamera,fader;
    // Use this for initialization
    private bool gamestart = false;
    public float zoom;
	void Start () {
        zoom = 20;
	}
	
	// Update is called once per frame
	void Update () {
        if (gamestart == true)
        {
            if(zoom >0)zoom -= 0.04f;
            if (zoom <= 14&& zoom >8)
            {
                
                if(zoom < 8)
                {
                    zoom = 8;
                }
                Maincamera.GetComponent<Camera>().orthographicSize = zoom;
            }
            else
            {
                if (zoom < 6)
                {
                    window.SetActive(true);
                    fader.SetActive(false);
                    gamestart = false;
                }
            }

        } 
	}
    public void GamesStart()
    {
        Logo.SetActive(false);
        button.SetActive(false);
        gamestart = true;
        
    }
}
