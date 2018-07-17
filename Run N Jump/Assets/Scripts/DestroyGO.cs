using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour {

    float destroyPos;

	// Use this for initialization
	void Start () {

        destroyPos = -(Camera.main.orthographicSize * Camera.main.aspect) - 3f;

	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < destroyPos)
            Destroy(gameObject);

	}
}
