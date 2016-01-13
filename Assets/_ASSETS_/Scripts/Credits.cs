using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine ("Wait");
	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds (4);
		Application.LoadLevel ("Opening");
	}
}
