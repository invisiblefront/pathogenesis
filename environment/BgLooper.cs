using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour {

	public Transform level_progress;

	public bool isNextPane=false;
	public Vector3 pane_pos;

	int numBgPanels=2;
	float widthOfBgObject;

	public int paneCount=0;

	GameObject cube;

	// level progress bar

	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(0,0);
	public Vector2 size = new Vector2(600,100);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		widthOfBgObject = ((BoxCollider2D)collider).size.x;
		pane_pos = collider.transform.position;
		pane_pos.x+=widthOfBgObject *numBgPanels;

		collider.transform.position = pane_pos;

		isNextPane=true;


	}

	void Update()
	{
		if(isNextPane)
		{
			paneCount++;
			isNextPane=false;

			barDisplay = Time.time*0.04f;
		}
	}

	void OnGUI()
	{

		int progressWidth = 600;

		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, Screen.height-20, progressWidth, size.y));
		GUI.Box(new Rect(0,0, progressWidth, size.y), emptyTex); 
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, progressWidth * barDisplay, size.y));
		GUI.Box(new Rect(0,0, progressWidth, size.y), fullTex); 
		GUI.EndGroup();
		GUI.EndGroup();
	}
}
