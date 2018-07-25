using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {
	public float incrementSize;
	void Update(){
		transform.localScale = transform.localScale + new Vector3 (incrementSize, incrementSize, incrementSize);
	}
}
