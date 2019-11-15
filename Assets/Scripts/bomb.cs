using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
	private Animator anim;
	private const string isBlowValName= "isBlowing";
	private const int blowTimer = 1;

	private bool isCollided = false;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		Destroy (this, 5);
	}
	
	// Update is called once per frame
	void Update () {		
	}

	public void ifCollision(){
		anim.SetBool (isBlowValName, true);
		Destroy (gameObject, blowTimer);
	}
		
}
