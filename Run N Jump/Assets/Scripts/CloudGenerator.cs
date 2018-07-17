using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

    public GameObject cloudPrefab;

    float spawnRate, timeToSpawn, scaleRand, spawnYPosRand, spawnXPos, moveSpeed;

    int scaleMul;

	// Use this for initialization
	void Start () {

        spawnRate = 5f;
        moveSpeed = 1f;
        timeToSpawn = 0f;

        spawnXPos = (Camera.main.orthographicSize * Camera.main.aspect) + 2f;

	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > timeToSpawn)
        {
            spawnYPosRand = Random.Range(1f, 4f);
            scaleRand = Random.Range(0.7f, 1.3f);

            scaleMul = Random.Range(-1, 2);
            while (scaleMul == 0)
                scaleMul = Random.Range(-1, 2);

            GameObject cloud = Instantiate(cloudPrefab, new Vector3(spawnXPos, spawnYPosRand, 0f), Quaternion.identity);
            cloud.transform.localScale = new Vector3(scaleRand * scaleMul, scaleRand, 1f);
            cloud.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0f);

            timeToSpawn = Time.time + spawnRate;
        }
		
	}
}
