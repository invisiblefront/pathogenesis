using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {


	float speed =-70f;

	Rigidbody2D player;

	void Start(){
		
		GameObject player_go = GameObject.FindGameObjectWithTag("Hero");
		
		if(player_go==null)
		{
			Debug.Log("Can find tag Player");
			return;
		}
		
		player = player_go.rigidbody2D;
	}


	// Update is called once per frame
	void FixedUpdate () {

		float velocty = player.velocity.x * 0.9f;
		transform.position=transform.position + Vector3.right * velocty *Time.deltaTime;
	}
}
