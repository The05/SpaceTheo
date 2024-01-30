using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Material Material1;
    public Material Material2;

    Rigidbody rb;
    new Renderer renderer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        SetGravity(false);
    }

    void SetGravity(bool gravity)
    {
        rb.useGravity = gravity;
        renderer.material = gravity ? Material2 : Material1;
    }

    public void ToggleState()
    {
        SetGravity(!rb.useGravity);
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
