using UnityEngine;
using System.Collections;

public class MissionStatementSwipe : MonoBehaviour {

	public Camera CameraObject;
	public CameraTracksPlayer CameraScript;
	public RedBloodCell hero;
    public Creator creator;


	public GUIStyle customGuiStyle;
	public float speed = 0.1F;

	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;
	
	public int tutorialCount=0;
	// Update is called once per frame

	bool hasGui=true;

	void OnGUI()
	{
		const int buttonWidth = 150;
		const int buttonHeight = 100;

		if(hasGui)
		{
			// Determine the button's place on screen
			// Center in X, 2/3 of the height in Y
			Rect NextLevelButton = new Rect(Screen.width-100,20,buttonWidth,buttonHeight);
			
			// Draw a button to start the game
			if(GUI.Button(NextLevelButton,"> Next", customGuiStyle))
			{
				moveCamera();
			}
		}
	}

	void moveCamera()
	{
		tutorialCount++;

		if(tutorialCount==2)
		{
            ///-------------------------- GAME IS STARTED -------------------------///

            creator.init();
			CameraScript.gameStarted=true;
			hero.gameStarted=true;
            
			hasGui=false;
			
		}
		else
		{
			CameraObject.transform.Translate(13f, 0f, 0f);
		}


	}

	void Update () {
		
		if (Input.touchCount > 0){
			
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
					
				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;
					
				case TouchPhase.Ended :
					
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}
						
						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								// MOVE RIGHT
								moveCamera();

							}else{
								// MOVE LEFT
moveCamera();
							}
						}
						
						if(swipeType.y != 0.0f ){
							if(swipeType.y > 0.0f){
								// MOVE UP
							}else{
								// MOVE DOWN
							}
						}
						
					}
					
					break;
				}
			}
		}
		
	}
}
