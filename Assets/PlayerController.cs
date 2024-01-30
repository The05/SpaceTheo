using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;
    public float Sensitivity = 3000;
    public float RotationSpeed = 200;
    public float PushForce = 2;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MainCamera.transform.position = transform.position;
        MainCamera.transform.rotation = transform.rotation;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            rb.useGravity = !rb.useGravity;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(PushForce * MainCamera.transform.forward);
        }
       

        float roll = Time.deltaTime * Sensitivity * Input.GetAxis("Mouse X");
        float pitch = Time.deltaTime * Sensitivity * Input.GetAxis("Mouse Y");
        float spin = 0f;
        if (rb.useGravity)
        {
            Quaternion rotation = Quaternion.LookRotation(MainCamera.transform.forward, Vector3.up);
            MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, rotation, Time.deltaTime / 0.1f);
        }

        else
        {
            if (Input.GetKey(KeyCode.A)){
                spin += Time.deltaTime * RotationSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                spin -= Time.deltaTime * RotationSpeed;
            }
        }
        MainCamera.transform.Rotate(pitch, roll, spin);
        MainCamera.transform.position = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        if (ball != null)
        {
            ball.ToggleState();
        }
    }
}
