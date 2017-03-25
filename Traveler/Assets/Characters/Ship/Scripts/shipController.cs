using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipController : MonoBehaviour {
	
	private float moveSpeed = 10.0f; // How fast the ship moves up/down
	private int health = 100; // Health of the ship
	int currentHealth;
	public int score = 0; // Player score
	public int level = 1;
	private float levelInterval = 15;
	private Rigidbody2D myRigidbody; // Player's rigidbody
	private Animator myAnimator;
	//private Animation myAnimation;
	public AudioClip pickUpSound;
	public AudioClip hitSound;
	public AudioClip darkMatterSound;
	public AudioClip deathSound;
	public AudioClip hitSound2;
	private SpriteRenderer mySprite;

	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> (); // Gets the rigidbody from the ship
		//myAnimation = GetComponent<Animation> ();
		myAnimator = GetComponent<Animator> ();
		mySprite = GetComponent<SpriteRenderer> ();
	}


	void Update () 
	{
		// Moves the ship up
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			if (Input.GetKey (KeyCode.LeftShift))
			{
				myRigidbody.velocity = new Vector2 (0, moveSpeed * 3);
			}
			else
			{
				myRigidbody.velocity = new Vector2 (0, moveSpeed);
			}
		}

		// Moves the ship down
		if (Input.GetKey(KeyCode.DownArrow)) 
		{
			if (Input.GetKey (KeyCode.LeftShift))
			{
				myRigidbody.velocity = new Vector2 (0, -moveSpeed * 3);
			}
			else
			{
				myRigidbody.velocity = new Vector2 (0, -moveSpeed);
			}
		}


		if (Time.time >= levelInterval * level)
		{
			level += 1;
		}

		if (level == 5 || level == 10 || level == 15 || level == 20)
		{
			levelInterval = 60;
		}
		else if (level > 5)
		{
			levelInterval = 15;
		}
		else if (level > 10)
		{
			levelInterval = 2;
		}
		if (level > 20)
		{
			SceneManager.LoadScene ("Scenes/Win");
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// if the player is hit by an enemy
		if (col.gameObject.tag == "Dark Matter")
		{
			// Insert a sound here!
			Debug.Log ("You hit dark matter!");
			AudioSource.PlayClipAtPoint (darkMatterSound, Camera.main.transform.position);
			health -= 20;
			Destroy (col.gameObject);
		}
		// if the player picks up an item
		if (col.gameObject.tag == "Item")
		{
			Debug.Log ("Increased score!");
			AudioSource.PlayClipAtPoint (pickUpSound, Camera.main.transform.position);
			score += 10;
			if (health <= 95)
			{
				health += 5;
			}
			Destroy (col.gameObject);
		}
		// if the player hits an alien
		if (col.gameObject.tag == "Alien")
		{
			Debug.Log ("You hit an alien!");
			AudioSource.PlayClipAtPoint (hitSound, Camera.main.transform.position);
			health -= 5;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Enemy Bullet")
		{
			Debug.Log ("You were shot!");
			AudioSource.PlayClipAtPoint (hitSound2, Camera.main.transform.position);
			health -= 10;
			Destroy (col.gameObject, 0.05f);
		}

		// if the player is dead
		if (health <= 0)
		{
			Debug.Log ("You died!");
			Destroy (this.gameObject, 5f);
			myAnimator.SetBool ("isDead", true);
			AudioSource.PlayClipAtPoint (deathSound, Camera.main.transform.position);
			StartCoroutine (Death ());
		}
	}

	public int getLevel()
	{
		return level;
	}

	void OnGUI()
	{
		// Display health
		GUI.color = Color.green;
		GUI.Label (new Rect (10, 10, 100, 20), "Health: " + health.ToString()); 

		// Display score
		GUI.color = Color.green;
		GUI.Label (new Rect (10, 40, 100, 20), "Score: " + score.ToString()); 

		// Display Level
		GUI.color = Color.green;
		GUI.Label (new Rect (10, 70, 100, 20), "Level: " + level.ToString()); 
	}

	IEnumerator Death()
	{
		yield return new WaitForSeconds (1);
		mySprite.color = new Color (1f, 1f, 1f, 0f);
		Destroy (this.GetComponent<Collider2D>());
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Scenes/Dead");
	}

}
