﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 rotationCamera = Vector3.zero;
    // Start is called before the first frame update
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate (Vector3 _rotation)
    {
        rotation = _rotation;
    }
    public void RotateCam (Vector3 _rotationCam)
    {
        rotationCamera = _rotationCam;
    }

    void Start()
    {
        rb = GetComponent <Rigidbody> ();
        cam = Camera.main;
    }
    void PerformMove ()
    {
        if (velocity != Vector3.zero)
        rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
    }

    void PerformRotation ()
    {
        rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
        if (cam != null)
            cam.transform.Rotate (-rotationCamera);
    }
    void FixedUpdate ()
    {
        PerformMove();
        PerformRotation ();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
