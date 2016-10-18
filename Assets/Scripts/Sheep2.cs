using UnityEngine;
using System.Collections;

public class Sheep2 : MonoBehaviour {

	public float sheepSpeed; 
	public float Spring;
	public float fallSpeedVertical; 
	public float fallSpeedHorizontal;


	public Rigidbody rb;

	private bool jumped = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (jumped == false) {
			rb.AddForce (new Vector2 (-sheepSpeed * Time.deltaTime, 0f), ForceMode.Impulse);
		}

		if (transform.position.x < -5 && jumped == true) {
			rb.AddForce (new Vector2 (-fallSpeedHorizontal, fallSpeedVertical), ForceMode.Impulse);
		}

		if (transform.position.x < -20) {
			Destroy (gameObject);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Spring" && Input.GetKeyDown (KeyCode.Space)) {
			jumped = true; 
			rb.AddForce (new Vector2 (0f, Spring * Time.deltaTime), ForceMode.Impulse);
		}
	}
}
