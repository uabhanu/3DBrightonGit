using UnityEngine;
using System.Collections;

public class BagScript : MonoBehaviour 
{
	[SerializeField] float pointValue = 100f;
	[SerializeField] GameObject effects;
	
	void OnTriggerEnter(Collider other)
	{
		//This functionality is added later
		if(GameManager.instance != null)
			GameManager.instance.AddToScore (pointValue);
		
		Instantiate (effects, transform.position, Quaternion.Euler(270f, 0f, 0f));
		
		gameObject.SetActive (false);
	}
}