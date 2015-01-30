using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {
	
	Transform player;
	float offsetX;
	
	public GameObject bglooper;
	public bool gameStarted=false;
	
	Vector3 pos;
	
	// Use this for initialization
	void Start(){


	
		GameObject player_go = GameObject.FindGameObjectWithTag("Hero");
		
		if(player_go==null)
		{
			return;
		}
		player = player_go.transform;

		if(gameStarted==true)
		{
		
			offsetX = transform.position.x - player.position.x;
		}
	}
	
	// Update is called once per frame
	void Update(){
		
		if(player != null && gameStarted==true)
		{
			pos=transform.position;
			pos.x=player.position.x+offsetX+3f;
			transform.position=pos;
		}
	}

}