using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisabler : MonoBehaviour {
	ParticleSystem particle;
	void Start(){
		particle = GetComponent<ParticleSystem> ();
	}
	void Update () {
		if (!particle.isPlaying)
			gameObject.SetActive (false);
	}
}
