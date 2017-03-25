using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour 
{
	public Button start;
	public Button quit;
	public Button controls;
	// Use this for initialization
	void Start () 
	{
		start = start.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		controls = controls.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartPress()
	{
		start.enabled = true;
		quit.enabled = false;
		controls.enabled = false;
		SceneManager.LoadScene("Scenes/Game");
	}

	public void ControlsPress()
	{
		start.enabled = false;
		quit.enabled = false;
		controls.enabled = true;
		SceneManager.LoadScene("Scenes/Controls");
	}
	public void QuitPress()
	{
		quit.enabled = true;
		start.enabled = false;
		controls.enabled = false;
	}
}
