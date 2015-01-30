using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour{

	public GUIText debugger;
	public GUIText oxygenCountText;

	public GUIStyle customGuiStyle;

	public RedBloodCell hero;

	// Use this for initialization
	void Start (){
	
	}
	
	// Update is called once per frame
	void Update () {

		oxygenCountText.text=hero.AbsorbedOxygen;
		debugger.text="swipe acceleration is: "+hero.Acceleratinon;
	}

	void OnGUI()
	{
		const int buttonWidth = 150;
		const int buttonHeight = 100;

		if(hero.gameStarted)
		{
			// Determine the button's place on screen
			// Center in X, 2/3 of the height in Y
			Rect AccelerateBtn = new Rect(Screen.width-150,50,buttonWidth,buttonHeight);
			
			// Draw a button to start the game
			if(GUI.Button(AccelerateBtn,"> Speed", customGuiStyle))
			{

			}
		}
	}
}
