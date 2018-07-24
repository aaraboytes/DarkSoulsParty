using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReflectorEffect : MonoBehaviour {
	[SerializeField]
	List<Player> playersInside = new List<Player> ();
	[SerializeField]
	List<Player> playersOutside = new List<Player>();
	public float timeToMakeDamage;
	float timer;
	void Start(){
		Player[] players = GameObject.FindObjectsOfType<Player>();
		foreach (Player p in players) {
			playersInside.Add (p);
		}
	}
	void Update(){
		timer += Time.deltaTime;
		if (timer > timeToMakeDamage) {
			foreach (Player p in playersOutside) {
				p.MakeDamage (1, p.transform.position - Vector3.up);
			}
			timer = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Player currentPlayer = other.GetComponent<Player> ();
			if (playersOutside.Contains (currentPlayer))
				playersOutside.Remove (currentPlayer);
			playersInside.Add (currentPlayer);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Player currentPlayer = other.GetComponent<Player> ();
			if (playersInside.Contains (currentPlayer))
				playersInside.Remove (currentPlayer);
			playersOutside.Add (currentPlayer);
		}
	}
}
