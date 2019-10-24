using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadectrl : MonoBehaviour {
	public void OnButtonFadeIn(){
		Fader.FadeIn ();
	}
	public void OnButtonFadeOut(){
		Fader.FadeOut ();
	}
	public void OnButtonSwitchScene(string sceneName){
		Fader.SwitchScene (sceneName);
	}
}
