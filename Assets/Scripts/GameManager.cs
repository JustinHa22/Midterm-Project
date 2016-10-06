using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Texture fadeOutTexture; // This texture will overlay the screen
	public float fadeOutSpeed; // The fading speed 

	private int drawDepth = -1000; // The texture's order in the draw hierarchy: a low number means it renders on top 
	private float alpha = 1.0f; // The texture's alpha value between 0 and 1 
	private int fadeDirection = -1; // The direction to fade: -1 = fade in and 1 = fade out

	void OnGUI (){
		// Fade out/in the alpha value using a direction, a speed and Time.deltaTimeto convert the operation to seconds
		alpha += fadeDirection * fadeOutSpeed * Time.deltaTime; 
		// Force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// Set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);	//set the alpha value
		GUI.depth = drawDepth; 													//make the black texture render on the top (drawn last)
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); //draw the texture to fit the entire screen 
	}
		
	// Sets fadeDirection to the direction parameter making the scene fade in if -1 and out if 1
	public float Beginfade (int direction){
		fadeDirection = direction;
		return (fadeOutSpeed);			// Return the fadeOutSpeed variable so it's easy to time the Application.Loadlevel();
	}

	// OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes 
	void OnLevelWasLoaded(){
		// alpha = 1; 		//Use this if the alpha is not set to 1 in default
		Beginfade(-1);		// Call the fade in function 
	}
}
