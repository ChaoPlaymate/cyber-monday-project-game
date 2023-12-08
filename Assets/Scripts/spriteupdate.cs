using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteupdate : MonoBehaviour
{
	public GameObject Parent;
	public int horiState;
	public int jumpState;
	public bool frozen;
	public float vertSpeed;
	private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = Parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horiState = Parent.GetComponent<PlayerMovement>().horiState;
		GetComponent<Animator>().SetInteger("horiState", horiState);
		jumpState = Parent.GetComponent<PlayerMovement>().jumpState;
		GetComponent<Animator>().SetInteger("jumpState", jumpState);
		frozen = Parent.GetComponent<PlayerMovement>().frozen;
		GetComponent<Animator>().SetBool("frozen", frozen);
		vertSpeed = rigid.velocity.y;
		GetComponent<Animator>().SetFloat("vertSpeed", vertSpeed);
    }
}
