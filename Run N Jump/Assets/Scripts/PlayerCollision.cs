using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    PlayerMovement pmScript;

	// Use this for initialization
	void Start () {

        pmScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            pmScript.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            pmScript.onLadder = false;
            pmScript.myRB.gravityScale = 1f;
        }
    }
}
