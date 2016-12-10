using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public AudioSource CoinSound;


	// PRIVATE INSTANCE VARIABLES
	private WaitForSeconds _waitTime = new WaitForSeconds(0.15f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.forward * Time.deltaTime * 360);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (this.PlayCoinSound ()); // invoke coroutine
		}
	}

	// Coroutine
	IEnumerator PlayCoinSound() {
		this.CoinSound.Play ();
		yield return this._waitTime;
		this.gameObject.SetActive (false); // disable game object
	}
}
