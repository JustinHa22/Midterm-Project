using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour {

	CharacterController cController; 

	public float moveSpeed; 
	public float cameraSpeed; 

	// Use this for initialization
	void Start () {
		cController = GetComponent<CharacterController> (); 
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis ("Horizontal"); // A/D keys control movement 
		float inputY = Input.GetAxis ("Vertical"); // W/S keys control movement 

		float MouseX = Input.GetAxis ("Mouse X"); // Turn left or right with mouse 
		float MouseY = Input.GetAxis ("Mouse Y"); // Look up or down 

		//Moves the player 
		cController.SimpleMove(transform.forward * inputY * moveSpeed + transform.right * inputX * moveSpeed); 

		//Player controls the view 
		transform.Rotate(-MouseY * cameraSpeed * Time.deltaTime, MouseX * cameraSpeed * Time.deltaTime, 0f); 
		//transform.Rotate (-MouseY * 5f * Time.deltaTime, 0f, 0f); 
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0f);


	}
}
