using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformScript : MonoBehaviour 
{
    BoxCollider boxCollider;
    MoneySpawnScript spawner;
    Socket[] sockets;

    [SerializeField] Transform otherPlatform;
	
	void Start()
	{
		sockets = otherPlatform.GetComponentsInChildren<Socket>();

		spawner = GetComponent<MoneySpawnScript>();
		boxCollider = GetComponent<BoxCollider>();
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
        {
            Invoke("Move" , 0.5f);
        }
	}
	
	void Move()
	{
		int index = Random.Range (0 , sockets.Length);
		transform.position = sockets [index].transform.position;
		transform.rotation = sockets [index].transform.rotation;

		float moveAmount = boxCollider.size.z / 2;
		transform.Translate (0f , 0f , moveAmount);

		//This functionality is added later
		if(spawner != null)
        {
            spawner.SpawnMoney ();
        }
	}
}
