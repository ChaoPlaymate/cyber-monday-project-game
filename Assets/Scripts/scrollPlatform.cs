using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollPlatform : MonoBehaviour
{
	public Vector3 startingPosition;
	public Vector3 endPosition;
	public bool placedPositionIsStart = true;
	private int state = 0;
	public float startingWaitTime = 1f;
	public float waitTime = 1f;
	public float timerSpeed = 1f;
	public float moveSpeed = 3f;
	// 0 = waiting at start, 1 = moving from start to end
	// 2 = waiting at end, 3 = moving from end to start
    
	// Start is called before the first frame update
    void Start()
    {
        if (placedPositionIsStart == true) {
			startingPosition = gameObject.transform.position;
		}
    }

    // Update is called once per frame
    void Update()
    {
        // wait at start
		switch(state)
		{
		case 0:
			waitTime -= (timerSpeed * Time.deltaTime);
			if (waitTime <= 0) {
				state = 1;
				waitTime = startingWaitTime;
			}
			break;
		
		case 1:
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + (moveSpeed * Time.deltaTime));
			if (gameObject.transform.position.z >= endPosition.z) {
				gameObject.transform.position = new Vector3(endPosition.x, endPosition.y, endPosition.z);
				state = 2;
			}
			break;
		case 2:
			waitTime -= (timerSpeed * Time.deltaTime);
			if (waitTime <= 0) {
				state = 3;
				waitTime = startingWaitTime;
			}
			break;
		case 3:
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (moveSpeed * Time.deltaTime));
			if (gameObject.transform.position.z <= startingPosition.z) {
				gameObject.transform.position = new Vector3(startingPosition.x, startingPosition.y, startingPosition.z);
				state = 0;
			}
			break;
		default:
			break;
		}
    }
}
