using UnityEngine;
using System.Collections;

public class MoneySpawnScript : MonoBehaviour 
{
	[SerializeField] GameObject moneyBags;
	[SerializeField] int numBags = 10;
	[SerializeField] float wDeviation = 2f;
	[SerializeField] float lDeviation = 15f;
	[SerializeField] float bagHeight = 1f;

	GameObject[] bags;

	void Start()
	{
		bags = new GameObject[numBags];
		for(int i = 0; i < bags.Length; i++)
		{
			bags[i] = (GameObject)Instantiate(moneyBags);
			bags[i].SetActive(false);
		}

		SpawnMoney ();
	}

	public void SpawnMoney()
	{
		for(int i = 0; i < bags.Length; i++)
		{
			bags[i].transform.position = transform.position;
			bags[i].transform.rotation = transform.rotation;
			bags[i].transform.Translate(Random.Range(-wDeviation, wDeviation), bagHeight, Random.Range (-lDeviation, lDeviation));
			bags[i].SetActive(true);
		}
	}
}
