using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movementSpeed = 135f;
    [SerializeField] float xRange = 20f;
    [SerializeField] float yRange = 12f;

    [Header("Pitch")]
    [SerializeField] float pitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    [Header("Yaw")]
    [SerializeField] float yawFactor = 1f;

    [Header("Roll")]
    [SerializeField] float rollFactor = -20f;

    [Header("Lasers")]
    [SerializeField] GameObject[] lasers;
    float xThrow, yThrow;
    void Start()
    {

    }


    void Update()
    {

        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    private void ProcessRotation()
    {
        //Pitch Calculations
        float pitchDueToPosition = transform.localPosition.y * pitchFactor;
        float pitchDueToControlPitchFactor = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = xThrow * rollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * movementSpeed;
        float yOffset = yThrow * Time.deltaTime * movementSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            LasersState(true);
        }
        else
        {
            LasersState(false);
        }
    }

    private void LasersState(bool isActive)
    {
        foreach (var laser in lasers)
        {
            var emissionOfLaser = laser.GetComponent<ParticleSystem>().emission;
            emissionOfLaser.enabled = isActive;
        }
    }

}
