﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 Offset;

    private void Start()
    {
        Offset = CalOffset();
    }

    Vector3 CalOffset ()
    {
        return   transform.position - target.position;
    }

    void LateUpdate()
    {
        if(target != null)
        transform.position = target.position + Offset;
    }
}
