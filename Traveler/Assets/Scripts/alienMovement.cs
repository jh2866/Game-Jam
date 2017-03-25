using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMovement : MonoBehaviour {

	private float speed = 3.5f;
	//private float yMax = 10.0f; 
	public GameObject alien;
	private float myTimer = 10.5f;
	private float startTime;
	private float delayTime = 15f;
	private int level = 1;
	//private int score;
	private int health = 100;
	public AudioClip hitSound;
	public AudioClip hitSound2;
	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
		//score = GameObject.Find ("Ship").GetComponent<shipController> ().score;
	}

	// Update is called once per frame
	void Update () 
	{
		level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
		if (level % 5 != 0)
		{
			transform.Translate (-speed * Time.deltaTime * level, 0, 0);
			myTimer -= Time.deltaTime;
			if (myTimer <= 0)
			{
				//GameObject.Instantiate (alien, new Vector3 (20, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				myTimer = 5.5f;
			}
			if (Time.time - startTime >= delayTime)
			{
				Destroy (this.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// if the player is hit by an enemy
		if (col.gameObject.tag == "Bullet")
		{
			health -= 50;
			AudioSource.PlayClipAtPoint (hitSound2, Camera.main.transform.position);
			Destroy (col.gameObject);
		}
		if (health <= 0)
		{
			AudioSource.PlayClipAtPoint (hitSound, Camera.main.transform.position);
			GameObject.Find ("Ship").GetComponent<shipController> ().score += 25;
			Destroy (gameObject);
		}
	}
}
