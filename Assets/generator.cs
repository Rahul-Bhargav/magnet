﻿using UnityEngine;
using System.Collections;

public class generator : MonoBehaviour {

    public static float gamespeed = 2.0f;
    
    Camera camera;
    float levelHeight;
    Vector3 levelGenPos;
    public GameObject[] levels ;

	void Start () 
    {
        camera = Camera.main;
        levelHeight = camera.orthographicSize*2;
        levelGenPos = new Vector3(camera.transform.position.x, camera.transform.position.y - levelHeight);
        this.transform.position = new Vector3(transform.position.x, camera.transform.position.y + camera.orthographicSize);
        spawnStart();
	}

	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.tag=="level")
        {
            Destroy(other.gameObject);
            int random = Random.Range(0, levels.Length);
            GameObject lev = Instantiate(levels[random], levelGenPos, Quaternion.identity) as GameObject;
            lev.GetComponent<Rigidbody2D>().velocity = new Vector2(0,gamespeed);
        }

    }

    void spawnStart()
    {
        int x = Random.Range(0, levels.Length);
        int y = Random.Range(0, levels.Length);
        GameObject lev;
        lev = Instantiate(levels[x], camera.transform.position, Quaternion.identity) as GameObject;
        lev.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gamespeed);
        lev = Instantiate(levels[y],levelGenPos, Quaternion.identity) as GameObject;
        lev.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gamespeed);
    }
}