using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controls : MonoBehaviour 
{
	public Button back;
	// Use this for initialization
	void Start () 
	{
		back = back.GetComponent<Button> ();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void BackPress()
	{
		back.enabled = true;
		SceneManager.LoadScene("Scenes/Title Screen");
	}
}
