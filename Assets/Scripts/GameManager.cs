using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Texture fadeOutTexture; // This texture will overlay the screen
	public float fadeOutSpeed; // The fading speed 

	private int drawDepth = -1000; // The texture's order in the draw hierarchy: a low number means it renders on top 
	private float alpha = 1.0f; // The texture's alpha value between 0 and 1 
	private int fadeDirection = -1; // The direction to fade: -1 = fade in and 1 = fade out


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
