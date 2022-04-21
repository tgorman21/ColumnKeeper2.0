using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamRig : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputActionMap camRigControls;
    [SerializeField] private InputActionAsset iaa;

    private Rigidbody rb;

    private void Awake()
    {
        //camRigControls["Move"].performed += Move;
        camRigControls["Move"].performed += ctx => Move(ctx);
        camRigControls["Height"].performed += ctx => Height(ctx);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        Vector2 move = ctx.ReadValue<Vector2>();
        Vector3 m = new Vector3(move.x, 0, move.y);

        rb.MovePosition(transform.position + m);
    }

    private void Height(InputAction.CallbackContext ctx)
    {
        float height = ctx.ReadValue<float>();
        Vector3 m = new Vector3(0, height, 0);

        rb.MovePosition(transform.position + m);
    }

    private void OnEnable()
    {
        camRigControls.Enable();
    }

    private void OnDisable()
    {
        camRigControls.Disable();
    }
}
