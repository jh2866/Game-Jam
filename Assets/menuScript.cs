using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour 
{
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () 
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}
	
	public void StartLevel()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
