using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Texture fadeOutTexture; // This texture will overlay the screen
	public float fadeOutSpeed; // The fading speed 

	public Text endScreen; 
	public TextMesh alarmClock; 

	static int wakeUpCount; 
	static int hour = 3; 
	static int firstMinutes = 0; 
	static int secondMinutes = 0; 
	static int framestoMinutes; 
	static float framestoSeconds; 
	static bool startClock = false; 

	private bool fallingAsleep = false;
	private bool sleepTime = false; 

	private bool enteringDream = false;

	static bool gameStart = false; 
	static bool gameOver = false; 

	private int drawDepth = -1000; // The texture's order in the draw hierarchy: a low number means it renders on top 
	public float alpha; // The texture's alpha value between 0 and 1 
	public int fadeDirection; // The direction to fade: -1 = fade in and 1 = fade out

	private int fadeBuffer = 0; 

	public static bool FenceHit = false; 

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

	void Awake(){
		Application.targetFrameRate = 60; 
	}

	void OnGUI (){
		if (sleepTime == true) {

			framestoSeconds += Time.deltaTime; 

			if (framestoSeconds > 59) {
				framestoSeconds = 0; 
				secondMinutes += 1;
			}

			if (secondMinutes > 9) {
				secondMinutes = 0; 
				firstMinutes += 1; 
			}
				

			if (Input.GetKeyDown (KeyCode.Space)) {
				fallingAsleep = true;
			}

			if (gameStart == false) {
				endScreen.text = "I should really press Space to sleep";
			}

			if (Input.GetKeyDown(KeyCode.Space) && gameStart == false) {
				gameStart = true;
				endScreen.text = ("");
			}
		}
		if (gameOver == false){
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
		}
			

		if (enteringDream == true) {
			Debug.Log ("works");
			// Fade out/in the alpha value using a direction, a speed and Time.deltaTimeto convert the operation to seconds
			alpha += fadeDirection * fadeOutSpeed * Time.deltaTime; 
			// Force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
			alpha = Mathf.Clamp01 (alpha);

			startClock = true; 
		}

		if (startClock == true) {
			framestoMinutes += 1;
			if (framestoMinutes % 60 == 0) {
				secondMinutes += 1;
			}
			if (secondMinutes > 9) {
				firstMinutes += 1; 
				secondMinutes = 0; 
			}
			if (firstMinutes > 5) {
				hour += 1; 
				firstMinutes = 0; 
			}
		}
			
		if (FenceHit == true) {
			SceneManager.LoadScene (0);
			FenceHit = false; 
			startClock = false;
			enteringDream = false; 
			wakeUpCount += 1; 
		}

		alarmClock.text = (hour + ":" + firstMinutes + secondMinutes + " AM"); 

			// Set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);	//set the alpha value
			GUI.depth = drawDepth; 													//make the black texture render on the top (drawn last)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); //draw the texture to fit the entire screen 

		if (hour == 7 && gameOver == false) {
			gameOver = true; 
			SceneManager.LoadScene (0);
		}

		if (gameOver == true) {
			//SceneManager.LoadScene (0);
			alarmClock.text = hour + ":" + 0 + 0 + " AM";
			endScreen.text = ("I woke up " + wakeUpCount + " times"); 
		}
	}
		
}
