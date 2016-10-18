using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheepSpawner : MonoBehaviour {

	public GameObject[] Sheep;
	public Text instructions;

	int bufferTime = 0; 
	int restartBuffer = 100; 
	int sheepCount = 0;

	public Vector2 sheepPosition; 
	// Use this for initialization
	void Start () {
		sheepPosition = new Vector2(transform.position.x, (transform.position.y - .47f));
	}
	
	// Update is called once per frame
	void Update () {
		int randomSheep = Random.Range (0, Sheep.Length);

		bufferTime += 1;

		if (bufferTime == restartBuffer) {
			Instantiate (Sheep [randomSheep], sheepPosition, Quaternion.Euler (0, 270, 0));
			bufferTime = 0;
			sheepCount += 1; 
		}
			
	}
}
