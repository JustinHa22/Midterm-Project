using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Texture fadeOutTexture; // This texture will overlay the screen
	public float fadeOutSpeed; // The fading speed 

	private bool fallingAsleep = false;
	private bool sleepTime = false; 

	private bool enteringDream = false;
	//private bool wakeUp = false; 

	private int drawDepth = -1000; // The texture's order in the draw hierarchy: a low number means it renders on top 
	public float alpha; // The texture's alpha value between 0 and 1 
	public int fadeDirection; // The direction to fade: -1 = fade in and 1 = fade out

	private int fadeBuffer = 0; 


	void Start(){
		Scene currentScene = SceneManager.GetActiveScene ();

		string sceneName = currentScene.name;

		if (sceneName == "Sleep Scene") {
			sleepTime = true; 
			Debug.Log ("works");
		}

		if (sceneName == "Dream Scene") {
			enteringDream = true;
		}

	}

	void OnGUI (){
		if (sleepTime == true) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				fallingAsleep = true;
			}
		}
		if (fallingAsleep == true) {
			// Fade out/in the alpha value using a direction, a speed and Time.deltaTimeto convert the operation to seconds
			alpha += fadeDirection * fadeOutSpeed * Time.deltaTime; 
			// Force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
			alpha = Mathf.Clamp01 (alpha);

			fadeBuffer += 1; 
			if (fadeBuffer == 250) {
				enteringDream = true;
				fadeBuffer = 0; 
				SceneManager.LoadScene (1);


			}

		}
			

		if (enteringDream == true) {
			// Fade out/in the alpha value using a direction, a speed and Time.deltaTimeto convert the operation to seconds
			alpha += fadeDirection * fadeOutSpeed * Time.deltaTime; 
			// Force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
			alpha = Mathf.Clamp01 (alpha);

			fadeBuffer += 1; 
			enteringDream = false;
		}
			

//			// Fade out/in the alpha value using a direction, a speed and Time.deltaTimeto convert the operation to seconds
//			alpha += fadeDirection * fadeOutSpeed * Time.deltaTime; 
//			// Force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
//			alpha = Mathf.Clamp01 (alpha);
//
//			fadeBuffer += 1; 

			// Set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);	//set the alpha value
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
