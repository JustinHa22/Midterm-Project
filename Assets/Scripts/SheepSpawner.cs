using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheepSpawner : MonoBehaviour {

	public GameObject[] Sheep;
	public Text instructions;

	int bufferTime = 0; 
	int restartBuffer = 100; 
	int sheepCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int randomSheep = Random.Range (0, Sheep.Length);

		bufferTime += 1;

		if (bufferTime == restartBuffer) {
			Instantiate (Sheep [randomSheep], transform.position, Quaternion.identity);
			bufferTime = 0;
			sheepCount += 1; 
		}
			
	}
}
