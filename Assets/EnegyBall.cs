using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegyBall : MonoBehaviour {
	public float incrementSize;
	void Update(){
		transform.localScale = transform.localScale + new Vector3 (incrementSize, incrementSize, incrementSize);
	}
}
