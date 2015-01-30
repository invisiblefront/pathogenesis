using UnityEngine;

public class menu : MonoBehaviour {

	public GUIStyle customGuiStyle;
	public GUIText score;

	void OnGUI()
	{
		const int buttonWidth = 300;
		const int buttonHeight = 150;

		score.text="your score: "+PlayerPrefs.GetInt("score");
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),(Screen.height / 2) - (buttonHeight / 2)+140,
			buttonWidth,
			buttonHeight
		);
	





		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"",customGuiStyle))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("level1");
		}


	}
}
