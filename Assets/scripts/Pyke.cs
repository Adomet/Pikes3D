﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy (other.transform.root.gameObject);
    }
}
