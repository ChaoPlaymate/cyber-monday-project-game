using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float horiSpeed = 0f;
	public float vertSpeed = 0f;
	public float horiAccel = 2f;
	public float horiSpeedCap = 5f;
	public float horiSpeedStop = 0.1f;
	public float horiDecel = 1f;
	public int horiState = 0;
	public int jumpState = 0;
	public float jumpForce = 10f;
	public float doubleJumpForce = 3f;
	public float jumpDecel = 1f;
	public float animRate = 1f;
	public float timer = 0f;
	public GameObject SpriteObject;
	public Sprite[] sprites;
	public GameObject DJParticle;
	private Rigidbody rigid;
	public int score = 0;
	public int HP = 3;
	public bool frozen = false;
	private Vector3 startPos;
	public bool victory = false;
	public AudioSource SFX;
	public bool isDead = false;
	public bool isInStage3 = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
		GetComponent<Collider>().material.dynamicFriction = 0;
		GetComponent<Collider>().material.staticFriction = 0;
		startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()

    {
		//if (frozen == false) {
			//------------------------------------------------------------
			//Update Sprites
			//------------------------------------------------------------
			//if (beinghurt == false) {
			//if (jumpState == 0) {
			//	if (horiState == 0) {
			//		SpriteObject.GetComponent<Animator>().Play("Idle");
			//	} else if (horiState == 1) {
			//		SpriteObject.GetComponent<Animator>().Play("Walk");
			//	} else if (horiState == 2) {
			//		SpriteObject.GetComponent<Animator>().Play("Run");
			//	}
			//} else if (jumpState == 1) {
			//	if (rigid.velocity.y > 0) {
			//		SpriteObject.GetComponent<Animator>().Play("Jump");
			//	} else {
			//		SpriteObject.GetComponent<Animator>().Play("Fall");
			//	}
			//} else {
			//	if (rigid.velocity.y > 0) {
			//		SpriteObject.GetComponent<Animator>().Play("Spin");
			//	} else {
			//		SpriteObject.GetComponent<Animator>().Play("Fall");
			//	}
			//}
			if (rigid.velocity.z >= 0.1) {
				SpriteObject.GetComponent<SpriteRenderer>().flipX = true;
			}
			if (rigid.velocity.z <= -0.1) {
				SpriteObject.GetComponent<SpriteRenderer>().flipX = false;
			}
			//}
			//------------------------------------------------------------
			// Sprite Timer
			//------------------------------------------------------------
			//if (timer > 0f) {
			//	timer -= 0.1f;
			//}
			//if (timer < 0f) {
			//	
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[2]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[3]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[4]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[5]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[6]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[7]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[10]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[11];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[11]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[12];
			//	}
			//	if (SpriteObject.GetComponent<SpriteRenderer>().sprite == sprites[12]) {
			//		timer = animRate;
			//		SpriteObject.GetComponent<SpriteRenderer>().sprite = sprites[10];
			//	}
			//}
			
			//------------------------------------------------------------
			//Horizontal State Updates: Idle - 1, Walking - 2, Running - 3
			//------------------------------------------------------------
				if (rigid.velocity.z == 0) {
					horiState = 0;
				} else if (Mathf.Abs(rigid.velocity.z) > (horiSpeedCap - 1)) {
					horiState = 2;
				} else if (Mathf.Abs(rigid.velocity.z) > 0) {
					horiState = 1;
				}
				if (Mathf.Abs(rigid.velocity.z) <= 0.001) {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, 0);
					horiState = 0;
				}
			//------------------------------------------------------------
			// Get Inputs
			//------------------------------------------------------------
			if (frozen == false) {
				if (Input.GetKey("d") && !Input.GetKey("a")) {
					if (rigid.velocity.z >= 0) {
						rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z +((horiAccel * 0.1f) * Time.deltaTime));
					} else {
						rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z +((horiAccel * 0.3f) * Time.deltaTime));
					}
				}
				if (Input.GetKey("a") && !Input.GetKey("d")) {
					if (rigid.velocity.z <= 0) {
						rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z -((horiAccel * 0.1f) * Time.deltaTime));
					} else {
						rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z -((horiAccel * 0.3f) * Time.deltaTime));
					}
				}
			}
			//------------------------------------------------------------
			// Deccelerate if there is no input horizontally
			//------------------------------------------------------------
			if (!Input.GetKey("a") && !Input.GetKey("d") && Mathf.Abs(rigid.velocity.z) > 0) {
				if (rigid.velocity.z > 0) {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z - ((horiDecel * 0.1f) * Time.deltaTime));
				} else {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z + ((horiDecel * 0.1f) * Time.deltaTime));
				}
			}
			if (Mathf.Abs(rigid.velocity.z) > horiSpeedCap) {
				if (rigid.velocity.z > 0) {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, horiSpeedCap);
				} else if (rigid.velocity.z < 0) {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, -horiSpeedCap);
				}
			}
			//------------------------------------------------------------
			//Jump Input
			//------------------------------------------------------------
			if (Input.GetKeyDown("space")) {
				if (jumpState == 0) {
					SFX.clip = Resources.Load<AudioClip>("Audio/SFX/jump");
					SFX.Play();
					jumpState = 1;
					rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, rigid.velocity.z);
					
				} else if (jumpState == 1) {
					SFX.clip = Resources.Load<AudioClip>("Audio/SFX/dub_jump");
					SFX.Play();
					jumpState = 2;
					rigid.velocity = new Vector3(rigid.velocity.x, doubleJumpForce, rigid.velocity.z);
					//create particles when double jumping
					DJParticle.GetComponent<ParticleSystem>().Play();
				} else {
					//do nothing.
				}
			}
			//------------------------------------------------------------
			// Deccelerate midair when jumping.
			//------------------------------------------------------------
			if (jumpState != 0) {
				rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y - (jumpDecel * Time.deltaTime), rigid.velocity.z);
			}
			if (rigid.velocity.y <= -1 && jumpState == 0) {
				jumpState = 1;
			}
			//------------------------------------------------------------
			// Game Over when zero health.
			//------------------------------------------------------------
			if (HP <= 0) {
				frozen = true;
				isDead = true;
			}
		}
		
		void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.tag == "Ground" && jumpState != 0) {
				jumpState = 0;
				rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
			}
			if (collision.gameObject.tag == "DeathPlane") {
				SFX.clip = Resources.Load<AudioClip>("Audio/SFX/OUCH");
				SpriteObject.GetComponent<Animator>().Play("hurt");
				HP -= 1;
				if (isInStage3 == false) {
					gameObject.transform.position = startPos;
				} else {
					gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z);
				}
			}
			if (collision.gameObject.tag == "Enemy") {
				SFX.clip = Resources.Load<AudioClip>("Audio/SFX/OUCH");
				SFX.Play();
				SpriteObject.GetComponent<Animator>().Play("hurt");
				if (SpriteObject.GetComponent<SpriteRenderer>().flipX == false) {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y + 9, rigid.velocity.z + 9);
				} else if (SpriteObject.GetComponent<SpriteRenderer>().flipX == true) {
					rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y + 9, rigid.velocity.z - 9);
				}
				HP -= 1;
			}
			
			
		}
		// Victory!!
		void OnTriggerEnter(Collider other) {
			if (other.gameObject.tag == "Goal") {
				victory = true;
				frozen = true;
				rigid.velocity = new Vector3(0, 0, 0);
				SpriteObject.GetComponent<Animator>().Play("victory");
			}
		}
	}
