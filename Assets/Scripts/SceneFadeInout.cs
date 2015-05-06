using UnityEngine;
using System.Collections;

public class SceneFadeInout : MonoBehaviour {
		
		public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
		public float fadeOutSpeed = 0.25f;
		private GUITexture guiTextureDude;
		private bool sceneStarting = true;      // Whether or not the scene is still fading in.
		private bool sceneEnding = false;
		private int theLevel;
		void Awake ()
		{
		guiTextureDude = gameObject.GetComponent<GUITexture> ();
			// Set the texture so that it is the the size of the screen and covers it.
			guiTextureDude.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		}
		
		
		void Update () {
			// If the scene is starting...
		if (sceneStarting) {
			// ... call the StartScene function.
			StartScene ();
		}
		if (sceneEnding) {
			FadeToBlack (theLevel);
			}
		}
		
		
		void FadeToClear ()
		{
			// Lerp the colour of the texture between itself and transparent.
			guiTextureDude.color = Color.Lerp(guiTextureDude.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
		
		
		public void FadeToBlack (int level) {
			// Lerp the colour of the texture between itself and black.
			theLevel = level;
			guiTextureDude.enabled = true;
			sceneEnding = true;
			sceneStarting = false;
			guiTextureDude.color = Color.Lerp(guiTextureDude.color, Color.black, fadeOutSpeed * Time.deltaTime);
			if (guiTextureDude.color.a >= 0.95f) {
			// ... reload the level.
			Application.LoadLevel (level);
			}
		}
		
		
		void StartScene ()
		{
			// Fade the texture to clear.
			FadeToClear();
			
			// If the texture is almost clear...
			if(guiTextureDude.color.a <= 0.05f)
			{
				// ... set the colour to clear and disable the GUITexture.
				guiTextureDude.color = Color.clear;
				guiTextureDude.enabled = false;
				
				// The scene is no longer starting.
				sceneStarting = false;
			}
		}
		
		
		
	}