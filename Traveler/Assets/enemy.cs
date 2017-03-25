using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour 
{
	private int enemyHealth = 100;
	public AudioClip hitSound;
	//private int level;
	//private bool enemySpawn;
	public AudioClip hitSound2;
	// Use this for initialization
	void Start () 
	{
		//level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
		//enemySpawn = GameObject.Find ("Background").GetComponent<backgroundScroll> ().enemySpawn;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// if the player is hit by an enemy
		if (col.gameObject.tag == "Bullet")
		{
			// Insert a sound here!
			//Debug.Log ("You hit dark matter!");
			AudioSource.PlayClipAtPoint (hitSound2, Camera.main.transform.position);
			Destroy (col.gameObject);
			enemyHealth -= 10;
			if (enemyHealth <= 0)
			{
				AudioSource.PlayClipAtPoint (hitSound, Camera.main.transform.position);
				//enemySpawn = true;
				Destroy (gameObject);
				GameObject.Find ("Ship").GetComponent<shipController> ().level += 1;
			}
		}
	}
}
