using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager _instance;
	[SerializeField]
	float scoreP1, scoreP2, scoreP3, scoreP4, scorePC;
	string lastWinner;
	List<string> names = new List<string> ();
	void Awake(){
		if (_instance == null) {
			_instance = this;
		} else if (_instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
	}
	public List<float> GetScores(){
		List<float> scores = new List<float> ();
		scores.Add (scoreP1);
		scores.Add (scoreP2);
		scores.Add (scoreP3);
		scores.Add (scoreP4);
		scores.Add (scorePC);
		return scores;
	}
	public void IncreaseScore(float extraScore,string player){
		switch (player) {
		case "P1.":
			scoreP1 += extraScore;
			break;
		case "P2.":
			scoreP2 += extraScore;
			break;
		case "P3.":
			scoreP3 += extraScore;
			break;
		case "P4.":
			scoreP4 += extraScore;
			break;
		default:
			scorePC += extraScore;
			break;
		}
	}
	public void SetLastWinner(string player){
		lastWinner = player;
	}
	public void ResetTakenNamesList(){
		names.Clear ();
	}
	public string ConsultScore(float score){
		string player;
		if (score == scoreP1 && !names.Contains("One"))
			player = "One";
		else if (score == scoreP2 && !names.Contains("Two"))
			player = "Two";
		else if (score == scoreP3 && !names.Contains("Three"))
			player = "Three";
		else if (score == scoreP4 && !names.Contains("Four"))
			player = "Four";
		else
			player = "PC";
		names.Add (player);
		return player;
	}
}
