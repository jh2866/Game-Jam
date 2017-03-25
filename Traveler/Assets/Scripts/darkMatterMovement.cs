using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkMatterMovement : MonoBehaviour 
{
	private float speed = 3f;
	//private float yMax = 10.0f; 
	public GameObject darkMatter;
	private float myTimer = 10.5f;
	private float startTime;
	private float delayTime = 15f;
	private int level = 1;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
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
				//GameObject.Instantiate (darkMatter, new Vector3 (20, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				myTimer = 10.5f;
			}
			if (Time.time - startTime >= delayTime)
			{
				Destroy (this.gameObject);
			}
		}
	}
}
