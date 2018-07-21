using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastAliveBallPlayer : MonoBehaviour {
	public List<BallController> players = new List<BallController>();
	public string winnerScene;
	public int extraScore;
	bool gameOver = false;
	// Use this for initialization
	void Start () {
		gameOver = false;
		BallController[] findPlayers = FindObjectsOfType<BallController> ();
		players.Clear ();
		for (int i = 0; i < findPlayers.Length; i++) {
			players.Add (findPlayers [i]);
		}
		foreach(BallController p in players){
			if (!p.isActiveAndEnabled) {
				players.Remove (p);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (players.Count > 1) {
			foreach (BallController p in players) {
				if (!p.alive) {
					players.Remove (p);
				}
			}
		} else {
			if (!gameOver) {
				string prefix = "";
				Transform playerTransform = this.transform;
				foreach (BallController p in players) {
					prefix = p.prefixInput;
					playerTransform = p.gameObject.transform;
				}
				GameManager._instance.IncreaseScore (extraScore, prefix);
				GameManager._instance.SetLastWinner (prefix);
				Debug.Log ("Winner" + prefix);
				CameraEffects3D._instance.setTarget (playerTransform);
				Invoke ("GoToWinnerScene", 2.5f);
				gameOver = true;
			}
		}
	}
	void GoToWinnerScene(){
		SceneManager.LoadScene (winnerScene);
	}
}
