﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;
using Valve.VR;

public class StartupController : MonoBehaviour
{
    public bool VRMode;

    public GameObject[] VRComponents;
    public GameObject[] FPSComponents;

    private void Awake()
    {
        if (VRMode)
        {
            // turn on VR mode for Unity
            XRSettings.enabled = true;
            
            for (int i = 0; i < VRComponents.Length; i++)
            {
                VRComponents[i].SetActive(true);
            }
            for (int i = 0; i < FPSComponents.Length; i++)
            {
                FPSComponents[i].SetActive(false);
            }
        }
        else
        {
            XRSettings.enabled = false;

            for (int i = 0; i < VRComponents.Length; i++)
            {
                VRComponents[i].SetActive(false);
            }
            for (int i = 0; i < FPSComponents.Length; i++)
            {
                FPSComponents[i].SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
