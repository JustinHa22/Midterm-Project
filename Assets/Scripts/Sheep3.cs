using UnityEngine;
using System.Collections;

public class Sheep3 : MonoBehaviour {

	public float sheepSpeed; 
	public float Spring;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(-sheepSpeed * Time.deltaTime, 0f), ForceMode.Impulse);
	}
		
	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Spring" && Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (new Vector2 (0f, Spring * Time.deltaTime), ForceMode.Impulse);
		}
	}
}
