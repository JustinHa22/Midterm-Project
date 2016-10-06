using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour {

	//CharacterController cController; 

	public float moveSpeed; 
	public float cameraSpeed; 

	// Use this for initialization
	void Start () {
		//cController = GetComponent<CharacterController> (); 
		//Vector3 playerPosition = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {


		float MouseX = Input.GetAxis ("Mouse X"); // Turn left or right with mouse 
		//float MouseY = Input.GetAxis ("Mouse Y"); // Look up or down 

		//Player can use the mouse to turn left or right 
		transform.Rotate(0f, MouseX * cameraSpeed * Time.deltaTime, 0f); 

	}
		

	IEnumerator Sleep () {

		yield return new WaitForSeconds(0.6f);

		// Fade out the game and load a new level 
		float fadeTime = GameObject.Find("GameManager").GetComponent<GameManager>().Beginfade(1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("Dream");
	}
}
