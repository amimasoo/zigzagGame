﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;

	[SerializeField]
    private float speed;
    Rigidbody rb;
    bool started;
	bool gameOver;
    //public GameObject camera;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start () {

        started = false;
    }
	
	// Update is called once per fr9ame
	void Update () {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (!started)
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

			GameManager.instance.StartGame();

            }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
           	rb.velocity = new Vector3(0, -25f, 0);

            //Camera.CameraFollow.gameOver = true;
            //Camera.main.gameOver() = true;

            GameManager.instance.GameOver();
            
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
	}

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.tag == "Diamond")
		{
			GameObject part= Instantiate(particle, col.transform.position, Quaternion.identity) as GameObject;
			Destroy(col.gameObject);
			Destroy(part, 1f);
		}
	}
}