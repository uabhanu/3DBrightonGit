using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour 
{
	[SerializeField] float timeToLive = 1f;


	void Start () 
	{
		Destroy (gameObject, timeToLive);
	}
}
