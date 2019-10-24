using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

	[SerializeField,Range(0.0f,1.0f)]
	float fadeLevel = 0.0f;
	UnityEngine.UI.Image fadeImage = null;

	// Use this for initialization
	void UpdateFade(float level){
		enabled = true;
		fadeLevel = Mathf.Clamp (level, 0.0f, 2.0f);

		if (fadeImage == null) {
			fadeImage = GetComponent<UnityEngine.UI.Image> ();
		}

		Color col = fadeImage.color;
		col.a = level;
		fadeImage.color = col;

		if (level < -0.0f) {
			enabled = false;	
		}
	}
	public void SetFadeLevel(float level){
		UpdateFade(level);
	}

	public void SetFadeColor(Color color){
		fadeImage.color = color;
		UpdateFade (fadeLevel);
	}
	void OnValidate(){
		UpdateFade (fadeLevel);
	}

	static Fader s_instance = null;
	public static Fader Instance{
		get {return s_instance;}
		}

	void Awake(){
		if (s_instance == null) {
			s_instance = this;
			
		} else {
			Destroy (this.gameObject);
		}
	}

	bool isend =false;

	public IEnumerator YieldFadeIn(float fadeTime = 1.0f){
		if (fadeTime == 0.0f) {
			UpdateFade (0.0f);
		} else {
			isend = false;
			float time = 0.0f;
			while(time < fadeTime){
				UpdateFade(1.0f-time/fadeTime);
				time += Time.deltaTime;
				yield return null;
			}
			UpdateFade(0.0f);
		}
		isend = true;
		yield return null;
	}
	public IEnumerator YieldFadeOut(float fadeTime = 1.0f){
		if (fadeTime == 0.0f) {
			UpdateFade (2.0f);
		} else {
			isend = false;
			float time = 0.0f;
			while(time < fadeTime){
				UpdateFade(time/fadeTime);
				time += Time.deltaTime;
				yield return null;
			}
			UpdateFade(1.0f);
		}
		isend = true;
		yield return null;
	}
	static public bool IsEnd
	{
		get{ return s_instance.isend;}
	}

	static public Coroutine FadeIn(float fadeTime = 1.0f){
		return s_instance.StartCoroutine (s_instance.YieldFadeIn (fadeTime));
	}


	static public Coroutine FadeOut(float fadeTime = 1.0f){
		return s_instance.StartCoroutine (s_instance.YieldFadeIn (fadeTime));
	}
	public IEnumerator YieldSwitchScene(string sceneName,float fadeTime = 1.0f){
		yield return YieldFadeOut (fadeTime);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		yield return YieldFadeIn (fadeTime);
	}
	static public Coroutine SwitchScene(string scenName,float fadeTime = 1){
		return s_instance.StartCoroutine (s_instance.YieldSwitchScene (scenName, fadeTime));
	}

}
