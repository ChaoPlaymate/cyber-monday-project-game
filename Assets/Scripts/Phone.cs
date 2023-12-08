using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
	public string jMode = "None";
	public string kMode = "None";
	public string lMode = "None";
	public GameObject JFunctionIcon;
	public GameObject KFunctionIcon;
	public GameObject LFunctionIcon;
	public int jModeBlocksState = 0; //0 = red active, 1 = blue active
    // Start is called before the first frame update
    void Start()
    {
        JFunctionIcon.GetComponent<Animator>().SetInteger("ActiveIcon", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j")) {
			if (jMode == "SwitchBlock") {
				switch(jModeBlocksState) {
					case 0:
						jModeBlocksState = 1;
						JFunctionIcon.GetComponent<Animator>().SetInteger("ActiveIcon", 1);
						break;
					case 1:
						jModeBlocksState = 0;
						JFunctionIcon.GetComponent<Animator>().SetInteger("ActiveIcon", 0);
						break;
					default:
						break;
				}
			}
		}
    }
}