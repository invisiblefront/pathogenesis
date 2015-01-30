using UnityEngine;
using System.Collections;

public class Oxygen : MonoBehaviour {
	
	bool isAbsorbed=false;
	float randmCellSize;
	float randomRotationSpeed;

	Transform redcell;

	// Use this for initialization
	void Start (){

		randmCellSize = Random.Range(0.5f, 1f);
		randomRotationSpeed = Random.Range(20f, 60f);

		transform.localScale = new Vector3(randmCellSize,randmCellSize,randmCellSize);
	}
	
	// Update is called once per frame
	void Update(){

		if(isAbsorbed)
		{
			// rotate oxygen cell around red bloodcell
			transform.RotateAround (redcell.position, Vector3.forward, randomRotationSpeed* Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//dead =true;
		string tmp = collision.collider.name.ToString();
		
		if(tmp=="Hero")
		{
			redcell=collision.collider.gameObject.transform;
			isAbsorbed = true;
		}
	}
}
