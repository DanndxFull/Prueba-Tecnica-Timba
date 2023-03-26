using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputSettings playerInputs;
    private Rigidbody rb;

    [SerializeField] float forceJump;
    [SerializeField] LayerMask ground;

    private void Awake()
    {
        playerInputs = new PlayerInputSettings();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInputs.Player.Jump.started += DoJump;
        playerInputs.Player.Enable();
    }    
    private void OnDisable()
    {
        playerInputs.Player.Jump.started -= DoJump;
        playerInputs.Player.Disable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * forceJump,ForceMode.Impulse);
        }
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver.instance.GameOverEvent();
        }
    }
}
