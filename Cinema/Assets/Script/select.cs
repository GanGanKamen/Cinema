using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class select : MonoBehaviour {
    static public bool isSelected = false;
    static public int BoneN = 05; public Text bone;
	static public int BridgeN = 01; public Text bridge;
    static public int RopeN = 02; public Text rope;
    static public int TuruhashiN = 01; public Text turuhashi;
    static public int LadderN = 02; public Text ladder;
    static public int FireN = 01; public Text fire;
    static public int BananaN = 01; public Text banana;
    public GameObject Story;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		bone.text = "×" + BoneN.ToString();
        bridge.text = "×" + BridgeN.ToString();
        rope.text = "×" + RopeN.ToString();
        turuhashi.text = "×" + TuruhashiN.ToString();
        ladder.text = "×" + LadderN.ToString();
        fire.text = "×" + FireN.ToString();
        banana.text = "×" + BananaN.ToString();
    }

    public void selectStory()
    {
        Story.SetActive(true);
    }

    public void closeStory()
    {
        Story.SetActive(false);
    }

    public void selectbone()
    {
		if (BoneN > 0 && isSelected == false) {
			// プレハブを取得
			GameObject prefab = (GameObject)Resources.Load ("Bone");
			// プレハブからインスタンスを生成
			Instantiate (prefab, new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.identity);
			BoneN--;
            isSelected = true;
		}
	}
	public void selectbrige()
	{
		if (BridgeN > 0 && isSelected == false) {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load ("Bridge");
			// プレハブからインスタンスを生成
			Instantiate (prefab, new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.Euler(0,90,0));
			BridgeN--;
            isSelected = true;
        }
	}

    public void selectrope()
    {
        if(RopeN > 0 && isSelected == false)
        {
            GameObject prefab = (GameObject)Resources.Load("Rope");
            Instantiate(prefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.Euler(0, 90, 0));
            RopeN--;
            isSelected = true;
        }
    }

    public void selectturuhashi()
    {
        if(TuruhashiN > 0 && isSelected == false)
        {
            GameObject prefab = (GameObject)Resources.Load("Turuhashi");
            Instantiate(prefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.identity);
            TuruhashiN--;
            isSelected = true;
        }
    }

    public void selectladder()
    {
        if(LadderN > 0 && isSelected == false)
        {
            GameObject prefab = (GameObject)Resources.Load("Ladder");
            Instantiate(prefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.Euler(0, 90.0f, 0));
            prefab.transform.Rotate(0.0f, 90.0f,0.0f);
            LadderN--;
            isSelected = true;
        }
    }

    public void selectfire()
    {
        if(FireN > 0 && isSelected == false)
        {
            GameObject prefab = (GameObject)Resources.Load("Fire");
            Instantiate(prefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.Euler(240.0f, 90.0f, 270.0f));
            FireN--;
            isSelected = true;
        }
    }

    public void selectbanana()
    {
        if(BananaN > 0 && isSelected == false)
        {
            GameObject prefab = (GameObject)Resources.Load("Banana");
            Instantiate(prefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 120), Quaternion.identity);
            BananaN--;
            isSelected = true;
        }
    }

}
