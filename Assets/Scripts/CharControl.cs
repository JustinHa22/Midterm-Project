using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour {

	//CharacterController cController; 

	public float moveSpeed; 
	public float cameraSpeed; 

	public bool closeEyes = false; 
	// Use this for initialization
	void Start () {
		//cController = GetComponent<CharacterController> (); 
		//Vector3 playerPosition = transform.position; 

	}
	
	// Update is called once per frame
	void Update () {

		float MouseX = Input.GetAxis ("Mouse X"); // Turn left or right with mouse 

		if (closeEyes == false) {
			//Player can use the mouse to turn left or right 
			transform.Rotate (0f, MouseX * cameraSpeed * Time.deltaTime, 0f); 
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			closeEyes = true; 
		}


	}
}
