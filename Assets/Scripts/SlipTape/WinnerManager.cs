using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinnerManager : MonoBehaviour {
	[Header("Scores in screen")]
	[SerializeField]
	public Text pos1;
	public Text pos2;
	public Text pos3;
	public Text pos4;
	List<float> scores = new List<float> ();
	List<string> names = new List<string>();
	[Header("Scene changing")]
	public List<string> scenes = new List<string>();
	public float timeToChangeScene;
	float timer = 0;

	void Start(){
		scores = GameManager._instance.GetScores();
		GameManager._instance.ResetTakenNamesList ();
		SetPositions ();
		FillSlots ();
	}
	[SerializeField]
	List<ScoreSlot> slots = new List<ScoreSlot>();
	class ScoreSlot{
		public string player;
		public float score;
		public ScoreSlot(string _player,float _score){
			player = _player;
			score = _score;
		}
	}
	void SetPositions(){
		float max = 0;
		int maxIndex= 0;
		if (scores.Count > 0) {
			for (int i = 0; i < scores.Count; i++) {
				if (scores [i] >= max) {
					max = scores [i];
					maxIndex = i;
				}
			}
		} else {
			return;
		}
		slots.Add (new ScoreSlot (GameManager._instance.ConsultScore(scores[maxIndex]),scores[maxIndex]));
		scores.Remove (scores [maxIndex]);
		SetPositions ();
	}
	void FillSlots(){
		pos1.text = slots [0].player + "\t\t" + slots [0].score;
		pos2.text = slots [1].player + "\t\t" + slots [1].score;
		pos3.text = slots [2].player + "\t\t" + slots [2].score;
		pos4.text = slots [3].player + "\t\t" + slots [3].score;
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer > timeToChangeScene) {
			int randScene = Random.Range (0, scenes.Count - 1);
			SceneManager.LoadScene (scenes [randScene]);
		}
	}
}