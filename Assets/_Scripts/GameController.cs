using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public Transform SpawnPoint;
	public GameObject Player;
	public GameObject Coin;
	public int MaxCoins = 20;


	// PRIVATE INSTANCE VARIABLES

	private List<GameObject> CoinPool;

	// Use this for initialization
	void Start () {
		Instantiate (this.Player);
		this.Player.transform.position = this.SpawnPoint.position;
		this.CoinPool = new List<GameObject> (); // instantiate new List Container
		this.BuildCoinPool();
	}
	
	// Update is called once per frame
	void Update () {
		this.PlaceCoins ();
	}

	private void BuildCoinPool() {
		for (int coinCount = 0; coinCount < this.MaxCoins; coinCount++) {
			GameObject coin = (GameObject)Instantiate (this.Coin); // creates an instance of the Coin Prefab
			coin.SetActive(false); // set coin to inactive / disabled
			this.CoinPool.Add (coin);
		}
	}

	private void PlaceCoins() {
		foreach (var coin in CoinPool) {
			if (!coin.activeInHierarchy) { // if coin is not in the scene
				coin.SetActive(true);
				coin.transform.position = new Vector3 (Random.Range (-20f, 20f), 20, Random.Range (-20f, 20f));
			}
		}
	}
}
