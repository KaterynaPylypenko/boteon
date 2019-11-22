using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
	private Animator anim;
	private AudioSource audioSource;
	private const string isBlowValName= "isBlowing";
	private const int blowTimer = 1;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		audioSource = this.GetComponent<AudioSource> ();
		Destroy (this, 5);
	}
	
	// Update is called once per frame
	void Update () {		
	}

	public void ifCollision(){
		anim.SetBool(isBlowValName, true);
		audioSource.Play();
		Destroy (gameObject, blowTimer);
	}
		
}
