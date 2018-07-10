using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	[Header("Setup Player")]
	InputController.PlayerNumber playerNumber;
	Rigidbody2D player;
	public int life;
	public bool alive;
	public float knockBackForce;
	public int currentLife;
	public float speed;
	public float jumpForce;
	public float jumpMultiplier;
	public float gravityIncreaser;
	public string prefixInput;
	[Header("Ground check")]
	[SerializeField]
	Transform groundChecker;
	public float groundCheckerRadius;
	public LayerMask layerMask;
	[Header("Animation")]
	SpriteRenderer playerSprite;
	Vector3 localSpriteScale;
	Animator anim;
	[Header("Audio")]
	public AudioClip damageSound,deadSound;
	AudioSource audio;
	[Header("Effects")]
	[SerializeField]
	private Pool bloodPool;
	//Local vars
	float horizontal;
	bool vertical;
	public bool jumping = false;

	void Awake(){
		prefixInput = InputController.GetPrefix (playerNumber);
	}
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(groundChecker.position,groundCheckerRadius);
	}
	void Start () {
		alive = true;
		player = GetComponent<Rigidbody2D> ();
		currentLife = life;
		anim = GetComponent<Animator> ();
		playerSprite = GetComponent<SpriteRenderer> ();
		localSpriteScale = playerSprite.transform.localScale;
		audio = GetComponent<AudioSource> ();
	}

	void Update () {
		//-------------------Inputs-------------------------------
		horizontal = Input.GetAxis (prefixInput + "Horizontal");
		vertical = Input.GetButton (prefixInput + "A");
		/*
		if (Input.GetButtonDown (prefixInput + "B")) {

		}
		if (Input.GetButtonDown (prefixInput + "X")) {

		}
		if (Input.GetButtonDown (prefixInput + "Y")) {

		}*/
		//----------------------------------------------------------
		//-----------------Movement---------------------------------
		if (isGrounded ()) {
			jumping = false;
		}
	}
	void FixedUpdate(){
		//Delta time
		float deltaTime = Time.deltaTime;
		//Horizontal
		player.velocity = new Vector2(horizontal*speed,player.velocity.y);
		//Vertical
		if (player.velocity.y > 0 && !vertical) {
			player.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * deltaTime;
		} else if (player.velocity.y < 0) {
			player.velocity += Vector2.up * Physics2D.gravity.y * (gravityIncreaser - 1) * deltaTime;	
		}
		if (vertical && !jumping) {
			player.AddForce (Vector2.up * jumpForce);
			jumping = true;
		}
		//Animations
		if (horizontal < 0) {
			playerSprite.transform.localScale = new Vector2(localSpriteScale.x*-1,localSpriteScale.y);
		} else {
			playerSprite.transform.localScale = localSpriteScale;
		}
		anim.SetFloat("velocity",Mathf.Abs(player.velocity.x)+Mathf.Abs(player.velocity.y)); 
	}
	bool isGrounded(){
		return Physics2D.OverlapCircle(groundChecker.position,groundCheckerRadius,layerMask);	
	}
	public void MakeDamage(int damage,Vector2 damageHit){
		currentLife -= damage;
		if (currentLife <= 0) {
			bloodPool.Recycle (player.position,Quaternion.identity);
			alive = false;
			gameObject.SetActive(false);
		} else {
			audio.clip = damageSound;
			audio.Play ();
			Vector2 knockBackDir = player.position - damageHit;
			player.AddForce (knockBackDir * knockBackForce);
		}
	}
}
