using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadMenu : MonoBehaviour
{

	//public Canvas loadMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start ()
	{
		//loadMenu = GetComponent<Canvas> ();
		startText = GetComponent<Button> ();
		exitText = GetComponent<Button> ();

	}

	public void StartLevel ()
	{
		Application.LoadLevel ("Level 01");
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}
}
