﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour 
{
	private float speed;
	private Vector2 _direction;
	bool isReady;

	void Awake()
	{
		speed = 10f;
		isReady = false;
	}
	// Use this for initialization
	void Start () 
	{

	}

	public void SetDirection(Vector2 direction)
	{
		_direction.x = direction.normalized.x;

		isReady = true;


	}

	// Update is called once per frame
	void Update () 
	{
		if (isReady)
		{
			Vector2 position = transform.position;

			position += -_direction * speed * Time.deltaTime;

			transform.position = position;

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

			if ((transform.position.x < min.x) || (transform.position.x > max.x) || 
				(transform.position.y < min.y) || (transform.position.y > max.y))
			{
				Destroy (gameObject);
			}
		}
	}
}
