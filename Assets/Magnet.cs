﻿using UnityEngine;
using System.Collections;
public class Magnet : MonoBehaviour {
	
	public Rigidbody2D rigidbody;
	public AudioClip absorb;
	public AudioClip hit;
	Animator animator;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
		AudioSource audio = GetComponent<AudioSource>();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	void Update () 
    {
       // if (Input.GetKey(KeyCode.W))
        //    rigidbody.AddForce(new Vector2(0,20));
       // if (Input.GetKey(KeyCode.S))
         //   rigidbody.AddForce(new Vector2(0, -20));
        if (Input.GetKey(KeyCode.A))
            rigidbody.AddForce(new Vector2(-50, 0));
        if (Input.GetKey(KeyCode.D))
            rigidbody.AddForce(new Vector2(50, 0));
	}

    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject.tag == "absorbable")
			{	
				animator.SetInteger("state",1);
                float weight = other.gameObject.GetComponent<Attractable>().Weight;
                Destroy(other.gameObject);
                rigidbody.mass += 0.02f;
                transform.localScale += new Vector3(0.02f, 0.02f,0f);
                MagEnvInteraction.CurrentFieldRadius = MagEnvInteraction.InitialFieldRadius * transform.localScale.x;
                Debug.Log(MagEnvInteraction.CurrentFieldRadius);
				GetComponent<AudioSource>().clip = absorb;	
				GetComponent<AudioSource>().Play ();
            }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
		animator.SetInteger ("state", 2);
        Debug.Log(other.gameObject.name);
        rigidbody.isKinematic = true;
        transform.parent = other.gameObject.transform;
		GetComponent<AudioSource>().clip = hit;
		GetComponent<AudioSource>().Play ();
	}
	
}
