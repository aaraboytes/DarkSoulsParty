using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PainterManager : MonoBehaviour {
	public static PainterManager _instance;
	public float timeToWin;
	float timer;
	public int scoreToWinner;
	public string winnerScene;
	public Slider p1BlockSlider;
	public Slider p2BlockSlider;
	public Slider p3BlockSlider;
	public Slider p4BlockSlider;
	public Text timerText;
	[SerializeField]
	List<Vector3>p1Blocks = new List<Vector3>();
	[SerializeField]
	List<Vector3>p2Blocks = new List<Vector3>();
	[SerializeField]
	List<Vector3>p3Blocks = new List<Vector3>();
	[SerializeField]
	List<Vector3>p4Blocks = new List<Vector3>();
	void Awake(){
		_instance = this;
	}
	void Start(){
		GameManager._instance.setPlayersOnScene ();
	}
	void Update(){
		timer += Time.deltaTime;
		timerText.text = ((int)timeToWin - (int)timer).ToString ();
		if (timer >= timeToWin) {
			string winnerPlayer = GetWinner ();
			GameManager._instance.IncreaseScore (scoreToWinner, winnerPlayer);
			SceneManager.LoadScene (winnerScene);
		}
		int totalBlocks = p1Blocks.Count + p2Blocks.Count + p3Blocks.Count + p4Blocks.Count;
		p1BlockSlider.value = (float)p1Blocks.Count / (float)totalBlocks;
		p2BlockSlider.value = (float)p2Blocks.Count / (float)totalBlocks;
		p3BlockSlider.value = (float)p3Blocks.Count / (float)totalBlocks;
		p4BlockSlider.value = (float)p4Blocks.Count / (float)totalBlocks;
	}
	public void AddBlock(Transform block){
		string player = block.GetComponent<PainterBlock> ().prefix;
		switch (player) {
		case "P1.":
			RemoveFromOtherLists (block.position, p1Blocks);
			if(!p1Blocks.Contains(block.position))
				p1Blocks.Add (block.position);
			break;
		case "P2.":
			RemoveFromOtherLists (block.position, p2Blocks);
			if (!p2Blocks.Contains (block.position))
				p2Blocks.Add (block.position);
			break;
		case "P3.":
			RemoveFromOtherLists (block.position, p3Blocks);
			if (!p3Blocks.Contains (block.position))
				p3Blocks.Add (block.position);
			break;
		case "P4.":
			RemoveFromOtherLists (block.position, p4Blocks);
			if (!p4Blocks.Contains (block.position))
				p4Blocks.Add (block.position);
			break;
		default:
			RemoveFromOtherLists (block.position, p1Blocks);
			if (!p1Blocks.Contains (block.position))
				p1Blocks.Add (block.position);
			break;
		}
	}

	void RemoveFromOtherLists(Vector3 block,List<Vector3> currentList){
		if (currentList != p1Blocks && p1Blocks.Contains (block))
			p1Blocks.Remove (block);
		if (currentList != p2Blocks && p2Blocks.Contains (block))
			p2Blocks.Remove (block);
		if (currentList != p3Blocks && p3Blocks.Contains (block))
			p3Blocks.Remove (block);
		if (currentList != p4Blocks && p4Blocks.Contains (block))
			p4Blocks.Remove (block);
	}

	string GetWinner(){
		int max = 0;
		string winnerPlayer = "";
		if (p1Blocks.Count > max)
			winnerPlayer = "P1.";
		if (p2Blocks.Count > max)
			winnerPlayer = "P2.";
		if (p3Blocks.Count > max)
			winnerPlayer = "P3.";
		if (p4Blocks.Count > max)
			winnerPlayer = "P4.";
		return winnerPlayer;
	}
}
