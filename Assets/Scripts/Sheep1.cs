using UnityEngine;
using System.Collections;

public class Sheep1 : MonoBehaviour {

	public float sheepSpeed; 
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(-sheepSpeed * Time.deltaTime, 0f), ForceMode.Impulse);
	}
}
