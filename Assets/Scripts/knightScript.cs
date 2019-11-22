using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;

public class knightScript : MonoBehaviour {

	public int health;
	public Slider healthSlider;

	//test firebase code
	public Text score;
	public int playerScore;
	public string playerName;

	public InputField nameText;

	private System.Random random = new System.Random ();
	//ublic Slider healthSlider;

	//This will be our maximum speed as we will always be multiplying by 1
	public float maxSpeed = 2f;
	//a boolean value to represent whether we are facing left or not
	bool facingLeft = false;
	//a value to represent our Animator
	private Animator anim;
	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		anim = this.GetComponent<Animator>();

		//test firebase code
		playerScore = random.Next(0,101);
		score.text = "Score:" + playerScore;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = health;
	}

	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");//Gives us of one if we are moving via the arrow keys
		//move our Players rigidbody
		rb.velocity = new Vector3 (move * maxSpeed, rb.velocity.y);	
		//set our speed
		anim.SetFloat ("speed",Mathf.Abs (move));

		//if we are moving left but not facing left flip, and vice versa
		if (move < 0 && !facingLeft) {
			Flip ();
		} else if (move > 0 && facingLeft) {
			Flip ();
		}

	}

	//flip if needed
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (null != collision) {
			bomb bombObj = collision.gameObject.GetComponentInChildren<bomb> ();
			if (null != bombObj) {
				bombObj.ifCollision ();
				//decrease player health level
				if (health > 0) {
					//healthSlider.value = health;
					health -= 30;
					Debug.Log ("Health =" + health);
				} else {
					//game over
				}

			}
			Debug.Log ("Collision");
		}
	}

	// test firebase
	public void onSubmit(){
		playerName = nameText.text;
		PostToDB ();
	}

	private void PostToDB() {
		Firebase firebase = Firebase.CreateNew("https://boteontest1.firebaseio.com","");
		FirebaseQueue firebaseQueue = new FirebaseQueue(true, 3, 1f); // if _skipOnRequestError is set to false, queue will stuck on request Get.LimitToLast(-1).
		firebaseQueue.AddQueuePush(firebase.Child(playerName, false), "{ \"score\": "+ playerScore + "}", true);
	}
}
