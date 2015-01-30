using UnityEngine;
using System.Collections;

public class RedBloodCell : MonoBehaviour {

	public float flapSpeed=90f;
    public float forwardSpeed=1f;
	public float currentXpos;
	public int amountAborbedOxygene;
	public bool absorbedOxygen=false;

	Vector3 velocity =Vector3.zero;
	Vector3 target;
	float oxygenRotationSpeed = 20.0f;
	bool didFlap=false;
	bool dead=false;
	GameObject oxygen;
	int life=5;

	public bool gameStarted=false;

	// swipe controller 

	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	private float swipeAcceleration=1f;
	private string swipeDirection;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
		
		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}

	// do gfx and input update here
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			didFlap=true;

			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}


		// ----------------------------- test for swipes ----------------------------- //

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
								swipeDirection="right";
								swipeAcceleration = gestureDist/100;
								
							}else{
								// MOVE LEFT
								swipeDirection="left";
								swipeAcceleration =0;
							}
						}
					}
					break;
				}
			}
		}
	}

	// do phsx update here
	void FixedUpdate(){

		if(gameStarted)
		{
			if(dead)
			return;

			rigidbody2D.AddForce(Vector2.right*swipeAcceleration);

			if(swipeDirection=="right")
			{

			}
			else if(swipeDirection =="left")
			{

			}



			if(didFlap)
			{
				float y_diff_up   = (target.y - transform.position.y)/3;
				float y_diff_down = (transform.position.y - target.y)/3;


				if(target.y > transform.position.y)
				{
					rigidbody2D.AddForce(Vector2.up*(flapSpeed*y_diff_up));
				}
				else 
				{
					rigidbody2D.AddForce(Vector2.up*(-flapSpeed*y_diff_down));
				}

				//rigidbody2D.AddForce(Vector2.right*forwardSpeed);
				didFlap=false;
			}

			currentXpos = rigidbody2D.position.x;

	     	// limit x speed
			if(rigidbody2D.velocity.x>3)
			{
				swipeAcceleration =1f;
			};

			AttactOxygen();
		}
	}

	void AttactOxygen()
	{
		if(absorbedOxygen){
			
			// stick each oxygen cell that hits red bloodcell to it and remove physx from it to concerve memory
			oxygen.transform.parent =transform;
			oxygen.rigidbody2D.isKinematic=true;
			Destroy(oxygen.collider2D);

			// make collision radio of hero larger
			CircleCollider2D heroCircleCollider = transform.GetComponent<CircleCollider2D>();
			// heroCircleCollider.radius = 0.6f;
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		string tmp = collision.collider.name.ToString();

		if(tmp=="pathogen(Clone)")
		{
			life--;

			if(life>=1)
			{
				animator.SetTrigger("hero_"+life+"_life");
			}
			else if (life<1)
			{
				animator.SetTrigger("hero_explode");
				StartCoroutine("Gameover");
			}
		}
		else if(tmp=="oxygen(Clone)")
		{
			oxygen = collision.collider.gameObject;
			absorbedOxygen =true;
			amountAborbedOxygene ++;
		}
	}

	IEnumerator Gameover(){
		yield return new WaitForSeconds(0.5f);
		PlayerPrefs.SetInt("score",amountAborbedOxygene);
		Application.LoadLevel("gameOver");
	}

	public string AbsorbedOxygen{
		get{return amountAborbedOxygene.ToString();}
	}

	public float Acceleratinon{
		get{return swipeAcceleration;}
	}
}