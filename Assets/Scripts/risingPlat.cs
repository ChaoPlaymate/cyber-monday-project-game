using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class risingPlat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (2f * Time.deltaTime), gameObject.transform.position.z);
    }
}
