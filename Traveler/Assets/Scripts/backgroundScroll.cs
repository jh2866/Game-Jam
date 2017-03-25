using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour 
{
	private float scrollSpeed = 0.03f; // Scroll speed of the background
	//public float boostSpeed;
	private float speed = 10f;
	private float yMax = 4.0f; 
	public GameObject item;
	public GameObject alien;
	public GameObject darkMatter;
	public GameObject enemyShip;
	private float itemTimer = 20.5f;
	private float darkMatterTimer = 10.5f;
	private float alienTimer = 10.5f;
	private float startTime;
	private float delayTime = 10f;
	private int level = 1;
	public bool enemySpawn = true;
	public shipController _shipController;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (enemyShip == null);
		level = GameObject.Find ("Ship").GetComponent<shipController> ().level;
		// Moves the background
		Vector2 offset = new Vector2 (Time.time * scrollSpeed * level, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;﻿

		// Moves the items
		//Debug.Log (startTime);
		item.transform.Translate (-speed * Time.deltaTime, 0, 0);

		// Updates myTimer
		itemTimer -= Time.deltaTime;
		darkMatterTimer -= Time.deltaTime;
		alienTimer -= Time.deltaTime;

		// Creates a new item
		if ((itemTimer <= 0) && (level % 5 != 0))
		{
			GameObject.Instantiate (item, new Vector3 (20, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			itemTimer = 20.5f;
		}
		if ((darkMatterTimer <= 0) && (level % 5 != 0))
		{
			GameObject.Instantiate (darkMatter, new Vector3 (20, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			darkMatterTimer = 5.5f;
		}
		if ((alienTimer <= 0) && (level % 5 != 0))
		{
			GameObject.Instantiate (alien, new Vector3 (20, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			alienTimer = 5.5f;
		}
		Debug.Log (enemySpawn);
		if (level % 5 == 0 && enemySpawn)
		{
			if (level == 5)
			{
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			}
			if (level == 10)
			{
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			}
			if (level == 15)
			{
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			}
			if (level == 20)
			{
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
				GameObject.Instantiate (enemyShip, new Vector3 (15, Random.Range (-yMax, yMax), 0), Quaternion.identity);
			}
			enemySpawn = false;
		}
		if (level % 5 != 0)
		{
			enemySpawn = true;
		}
			
			

		// Destroys the item after delay time
		if (Time.time - startTime >= delayTime)
		{
			DestroyImmediate (item.gameObject);
		}
	}
}
