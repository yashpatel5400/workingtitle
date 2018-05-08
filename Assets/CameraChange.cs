﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
    public int animationTime;

    public Camera animationCamera;
    public Camera fpsCamera;
    public Camera minimapCamera;

    public GameObject ignored;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(animator());
    }

    IEnumerator animator()
    {
        GameObject[] minimapObjects = GameObject.FindGameObjectsWithTag("Minimap");

        foreach (GameObject minimapObject in minimapObjects)
        {
            minimapObject.SetActive(false);
        }

        animationCamera.GetComponent<Camera>().enabled = true;
        fpsCamera.GetComponent<Camera>().enabled = false;
        minimapCamera.GetComponent<Camera>().enabled = false;

        ignored.SetActive(false);

        yield return new WaitForSeconds(animationTime);

        animationCamera.GetComponent<Camera>().enabled = false;
        fpsCamera.GetComponent<Camera>().enabled = true;
        minimapCamera.GetComponent<Camera>().enabled = true;

        foreach (GameObject minimapObject in minimapObjects)
        {
            minimapObject.SetActive(true);
        }

        ignored.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
