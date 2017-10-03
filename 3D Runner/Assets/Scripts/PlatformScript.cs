using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformScript : MonoBehaviour 
{
    BoxCollider m_boxCollider;
    MoneySpawnScript m_moneySpawner;
    Socket[] m_sockets;

    [SerializeField] Transform m_otherPlatform;
	
	void Start()
	{
		m_sockets = m_otherPlatform.GetComponentsInChildren<Socket>();

		m_moneySpawner = GetComponent<MoneySpawnScript>();
		m_boxCollider = GetComponent<BoxCollider>();
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
		int index = Random.Range(0 , m_sockets.Length);
		transform.position = m_sockets[index].transform.position;
		transform.rotation = m_sockets[index].transform.rotation;

		float moveAmount = m_boxCollider.size.z / 2;
		transform.Translate(0f , 0f , moveAmount);

		//This functionality is added later
		if(m_moneySpawner != null)
        {
            m_moneySpawner.SpawnMoney();
        }
	}
}
