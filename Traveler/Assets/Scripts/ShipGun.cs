using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour {

	public GameObject bulletGO;
	//private  float fireTime = 3f;

	// Use this for initialization
	void Start () 
	{
		//InvokeRepeating ("FireEnemyBullet", 1f, fireTime);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			FireBullet ();
		}
	}

	void FireBullet()
	{
		GameObject bullet = (GameObject)Instantiate (bulletGO);
		bullet.transform.position = transform.position;
		//Debug.Log (bullet.transform.position);
		Vector2 direction = bullet.transform.position;

		bullet.GetComponent<bullet> ().SetDirection (direction);
	}
}
