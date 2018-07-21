using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointManager : MonoBehaviour {
	public static FollowPointManager _instance;
	public GameObject followPoint;
	public List<Transform> spawnPoints = new List<Transform> ();
	[SerializeField]
	List<Player> players = new List<Player>();
	[SerializeField]
	List<Player> goaledPlayers = new List<Player> ();

	void Awake(){
		_instance = this;
	}
	void Start(){
		Player[] currentPlayers = FindObjectsOfType<Player> ();
		for (int i = 0; i < currentPlayers.Length; i++) {
			if (currentPlayers [i].isActiveAndEnabled) {
				players.Add (currentPlayers [i]);
				currentPlayers [i] = null;
			}
		}
		MoveFollowPoint ();
	}
	public void Goal(Player currentPlayer){
		if(!goaledPlayers.Contains(currentPlayer))goaledPlayers.Add (currentPlayer);
		if (goaledPlayers.Count >= players.Count - 2) {
			foreach (Player p in players) {
				if (!goaledPlayers.Contains (p)) {
					p.MakeDamage (100, transform.position);
					break;
				}
			}
			Invoke ("CheckAlivePlayers", 0.2f);
			MoveFollowPoint ();
			goaledPlayers.Clear ();
		}
	}
	void CheckAlivePlayers(){
		foreach (Player p in players) {
			if (!p.isActiveAndEnabled) {
				players.Remove (p);
			}
		}
	}
	void MoveFollowPoint(){
		followPoint.SetActive (false);
		followPoint.transform.position = spawnPoints [Random.Range (0, spawnPoints.Count - 1)].localPosition;
		followPoint.SetActive (true);
	}
}
