using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainState : MonoBehaviour {
	private bool onFocus;

	private bool onCrossFocus;
	public GameObject crossTrigger;
	public Vector2 trigerCross;

	private bool onNearbyFocus;
	public Vector2 triggerNearby;

	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		onFocus = false;
		onCrossFocus = false;
		onNearbyFocus = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (onFocus) {
			OnNearbyCollider ();
		}
		colorCheck ();
	}

	//On Focus
	void OnMouseEnter() {
		onFocus = true;
	}

	void OnMouseExit() {
		onFocus = false;
	}

	//On Nearby-Focus
	void OnNearbyCollider() {
		Collider2D[] areNearby = Physics2D.OverlapBoxAll (transform.position , triggerNearby, 0);
		if(areNearby.Length>0){
			for(int i = 0; i < areNearby.Length; i++){
				if(areNearby [i].gameObject.tag == "Tile"){
					areNearby [i].gameObject.GetComponent<mainState>().onNearbyFocus = true;
				}
			}
		}
	}

	//void OnCollisionEnter2D(Collision2D other){
	//	print ("opp");
	//}

	void colorCheck(){
		if (onFocus) {
			rend.material.color = Color.black;
		} else {
			rend.material.color = Color.white;
		}
		if (onNearbyFocus) {
			rend.material.color = Color.red;
		}
		if (onCrossFocus) {
			rend.material.color = Color.blue;
		} 
	}
}
