using UnityEngine;
using System.Collections;


public class NextLevelManager : MonoBehaviour {


	public GUIStyle customGuiStyle;

	void OnGUI()
	{
		const int buttonWidth = 150;
		const int buttonHeight = 100;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect NextLevelButton = new Rect(Screen.width / 2 - (buttonWidth / 2),(Screen.height / 2) - (buttonHeight / 2)+20,buttonWidth,buttonHeight);
		
		// Draw a button to start the game
		if(GUI.Button(NextLevelButton,"> Next level", customGuiStyle))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("level1");
		}

		Rect ExitGameButton = new Rect(Screen.width / 2 - (buttonWidth / 2),(Screen.height / 2) - (buttonHeight / 2)+150,buttonWidth,buttonHeight);
		// Draw a button to start the game
		if(GUI.Button(ExitGameButton,"> Exit game", customGuiStyle))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.Quit();
		}
	}
}
