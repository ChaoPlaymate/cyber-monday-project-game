using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockFolder : MonoBehaviour
{
	public int cursorsNeeded = 3;
	public GameObject PlayerObject;
	public GameObject Collider;
	public GameObject LockNumber;
	public AudioSource Asource;
	
    // Start is called before the first frame update
    void Start()
    {
        Asource = GameObject.Find("PlayerSounds").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other) {
			if (other.gameObject.tag == "Player") {
				if (PlayerObject.GetComponent<PlayerMovement>().score >= cursorsNeeded) {
					Collider.SetActive(false);
					Asource.clip = Resources.Load<AudioClip>("Audio/SFX/foldr");
					Asource.Play();
					gameObject.GetComponent<Animator>().Play("unlock");
					PlayerObject.GetComponent<PlayerMovement>().score -= cursorsNeeded;
				}
			}
		}
}