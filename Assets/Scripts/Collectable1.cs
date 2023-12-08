using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable1 : MonoBehaviour
{
	public bool collected = false;
	public GameObject spriteobj;
	public GameObject PlayerObject;
	public AudioSource ASource;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ASource = GameObject.Find("PlayerSounds").GetComponent<AudioSource>();
    }
	
	private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player") {
		ASource.clip = Resources.Load<AudioClip>("Audio/SFX/blip");
		ASource.Play();
        PlayerObject.GetComponent<PlayerMovement>().score += 1;
		gameObject.SetActive(false);
		}
    }
}
