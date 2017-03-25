using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMovement : MonoBehaviour 
{
	private float speed = 5f;
	//private float yMax = 10.0f; 
	public GameObject item;
	private float myTimer = 5.5f;
	private float startTime;
	private float delayTime = 10f;
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
		transform.Translate (-speed * Time.deltaTime * level, 0, 0);
		myTimer -= Time.deltaTime;
		if (myTimer <= 0)
		{
			myTimer = 5.5f;
		}
		if (Time.time - startTime >= delayTime)
		{
			Destroy (this.gameObject);
		}
	}
}
