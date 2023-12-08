using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class uiEffects : MonoBehaviour
{
	public GameObject HP1;
	public GameObject HP2;
	public GameObject HP3;
	public GameObject HP1back;
	public GameObject HP2back;
	public GameObject HP3back;
	public GameObject Player;
	public GameObject CursorCount;
	public int PlayerHealth;
	public int Score;
	public bool victory = false;
	public GameObject VictoryText;
	public GameObject GameOverText;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		switch(PlayerHealth)
		{
        case 3: 
			HP1.SetActive(true);
			HP2.SetActive(true);
			HP3.SetActive(true);
			HP1back.SetActive(false);
			HP2back.SetActive(false);
			HP3back.SetActive(false);
			break;
		case 2:
			HP1.SetActive(true);
			HP2.SetActive(true);
			HP3.SetActive(false);
			HP1back.SetActive(false);
			HP2back.SetActive(false);
			HP3back.SetActive(true);
			break;
		case 1:
			HP1.SetActive(true);
			HP2.SetActive(false);
			HP3.SetActive(false);
			HP1back.SetActive(false);
			HP2back.SetActive(true);
			HP3back.SetActive(true);
			break;
		default:
			HP1.SetActive(false);
			HP2.SetActive(false);
			HP3.SetActive(false);
			HP1back.SetActive(true);
			HP2back.SetActive(true);
			HP3back.SetActive(true);
			break;
		}
		Score = Player.GetComponent<PlayerMovement>().score;
		CursorCount.GetComponent<TMP_Text>().text = new String("x " + Score);
		PlayerHealth = Player.GetComponent<PlayerMovement>().HP;
		victory = Player.GetComponent<PlayerMovement>().victory;
		if (victory == true) {
			VictoryText.SetActive(true);
		}
		if (Player.GetComponent<PlayerMovement>().isDead == true) {
			GameOverText.SetActive(true);
		}
    }
}
