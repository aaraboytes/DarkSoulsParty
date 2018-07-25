using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastAlivePlayer : MonoBehaviour {
	public List<Player> players = new List<Player>();
	public string winnerScene;
	public int scoreToWinner = 100;
	bool gameOver = false;
	// Use this for initialization
	void Start () {
		gameOver = false;
		GameManager._instance.setPlayersOnScene ();
		Player[] findPlayers = FindObjectsOfType<Player> ();
		players.Clear ();
		for (int i = 0; i < findPlayers.Length; i++) {
			players.Add (findPlayers [i]);
		}
		foreach(Player p in players){
			if (!p.isActiveAndEnabled) {
				players.Remove (p);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (players.Count > 1) {
			foreach (Player p in players) {
				if (!p.alive) {
					players.Remove (p);
				}
			}
		} else {
			if (!gameOver) {
				string prefix = "";
				Transform playerTransform = this.transform;
				foreach (Player p in players) {
					prefix = p.prefixInput;
					playerTransform = p.transform;
				}
				GameManager._instance.IncreaseScore (scoreToWinner, prefix);
				GameManager._instance.SetLastWinner (prefix);
				Debug.Log ("Winner" + prefix);
				CameraEffects._instance.FocusOnWinner (playerTransform);
				Invoke ("GoToWinnerScene", 2.5f);
				gameOver = true;
			}
		}
	}
	void GoToWinnerScene(){
		SceneManager.LoadScene (winnerScene);
	}
}
