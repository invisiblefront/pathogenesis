using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creator : MonoBehaviour {


	public Transform white_cell;
	public Transform pathogen;
	public Transform oxygen;

	public RedBloodCell hero;
	public BgLooper bglooper;
	
	int numRedBloodCells=12;
	int numPathogens =30;
	int numOxygen =20;

	int panesToNextLevel=14;
   
	
	void Start(){

	}

    public void init()
    {
		createWhiteCellPool();
		createPathogens();
		createOxygenCells();
    }

	void createOxygenCells()
	{
		for(int i = 0; i < numOxygen; i++)
		{
			Vector3 tmp = new Vector3(i*Random.Range(0f, 30f), Random.Range(2f, 4f),0);
			Instantiate(oxygen, tmp, Quaternion.identity);
		}
	}
	
	void createWhiteCellPool()
	{
		for(int i = 0; i < numRedBloodCells; i++)
		{
			Vector3 tmp = new Vector3(i*Random.Range(5f, 30f), Random.Range(2f, 4f),0);
			Instantiate(white_cell, tmp, Quaternion.identity);
		}
	}

	void createPathogens()
	{
		for(int i = 0; i < numPathogens; i++)
		{
			Vector3 tmp = new Vector3(i*Random.Range(3f, 30f), Random.Range(2f, 4f),0);
			Instantiate(pathogen, tmp, Quaternion.identity);
		}
	}
	
	void Update()
	{
			if(bglooper.paneCount==panesToNextLevel)
			{
				Application.LoadLevel("nextLevelNotification");
				PlayerPrefs.SetInt("score",hero.amountAborbedOxygene);
			}

			if(hero.absorbedOxygen)
			{

			}
	}
}
