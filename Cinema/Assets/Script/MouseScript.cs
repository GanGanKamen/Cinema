using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
	static public int cursorNum;

    [SerializeField]
    private Texture2D mouse;
	private Texture2D bridge;
    private Vector3 position;
    public static int set;
    // Use this for initialization
    void Start() {
		cursorNum = 0;
        set = 0;      
    }

    // Update is called once per frame
    void Update(){
        if (set == 0)
        {
			if (cursorNum == 0) {
				Cursor.SetCursor (mouse, new Vector2 (30, 15), CursorMode.ForceSoftware);
                set = 1;
			}  

        }
    }
}
