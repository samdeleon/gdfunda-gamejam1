﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] WallRun wallRun;

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Transform cam = null;
    [SerializeField] Transform orientation = null;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private bool toggleCam = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.TOGGLE_MENU, this.CamToggle);
    }

    private void Update()
    {
        if (toggleCam)
        {
            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            yRotation += mouseX * sensX * multiplier;
            xRotation -= mouseY * sensY * multiplier;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    void CamToggle()
    {
        toggleCam = !toggleCam;
    }
}
