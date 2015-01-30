using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GUIStyle customGuiStyle;
	public GUIText score;

	void OnGUI()
	{
		const int buttonWidth = 350;
		const int buttonHeight = 100;

		score.text="your score: "+PlayerPrefs.GetInt("score");
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(Screen.height / 2),
			buttonWidth,
			buttonHeight
			);

        Rect ExitGameButton = new Rect(Screen.width / 2 - (buttonWidth / 2),(Screen.height / 2) - (buttonHeight / 2)+250,buttonWidth,buttonHeight);

		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"> Replay",customGuiStyle))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("level1");
		}

		
		// Draw a button to start the game
		if(GUI.Button(ExitGameButton,"> Exit game", customGuiStyle))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.Quit();
		}
	}
}
