using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrownManager : MonoBehaviour {
	public static CrownManager _instance;
	public float timeToWin;
	public int scoreToWinner;
	public string winnerScene;

	[Serializable]
	class PlayerScore{
		public float time;
		public string player;
		public PlayerScore(float currentTime,string _player){
			time = currentTime;
			player = _player;
		}
		public void IncrementTime(float addedTime){
			time += addedTime;
		}
	};
	[SerializeField]
	List<PlayerScore> playersScores = new List<PlayerScore>();
	PlayerScore currentPlayer;
	public List<Player> players = new List<Player>();

	void Awake(){
		_instance = this;
	}
	void Start(){
		foreach (Player p in players) {
			if (!p.isActiveAndEnabled) {
				players.Remove (p);
			}
		}
		foreach (Player p in players) {
			PlayerScore ps = new PlayerScore (0, p.prefixInput);
			playersScores.Add (ps);
		}
	}
	void Update(){
		if (currentPlayer != null) {
			currentPlayer.IncrementTime (Time.deltaTime);
			if (currentPlayer.time >= timeToWin) {
				GameManager._instance.IncreaseScore (scoreToWinner, currentPlayer.player);
				SceneManager.LoadScene (winnerScene);
			}
		}
	}
	public void setCurrentPlayer(string prefix){
		foreach (PlayerScore ps in playersScores) {
			if (prefix == ps.player && currentPlayer!= ps) {
				currentPlayer = ps;
				return;
			}
		}
	}
}
