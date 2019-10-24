using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
    public GameObject Camera;
    public UnityEngine.UI.Slider cameraWork;
    public static float posX;
	// Use this for initialization
	void Start () {
        posX = 20.0f;
        cameraWork.onValueChanged.AddListener(OnChangeCameraWork);
	}
	
	// Update is called once per frame
	void Update () {
        Camera.transform.position = new Vector3(posX, 4.0f, -20.0f);
    }

    public void OnChangeCameraWork(float position)
    {
        posX = position;
    }
}
