using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour 
{

	public GameObject enemyBulletGO;
	private  float fireTime = 3f;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("FireEnemyBullet", 1f, fireTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FireEnemyBullet()
	{
		GameObject playerShip = GameObject.Find ("Ship");

		if (playerShip != null)
		{
			GameObject bullet = (GameObject)Instantiate (enemyBulletGO);

			bullet.transform.position = transform.position;
			//Debug.Log (bullet.transform.position);
			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			bullet.GetComponent<enemyBullet> ().SetDirection (direction);
		}
	}
}
