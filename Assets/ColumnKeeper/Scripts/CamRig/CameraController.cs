using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Configurable Properties")]
    [Tooltip("This is the Y offset of our focal point. 0 Means we're looking at the ground.")]
    public float LookOffset;
    [Tooltip("The angle that we want the camera to be at.")]
    public float CameraAngle;
    [Tooltip("The default amount the player is zoomed into the game world.")]
    public float DefaultZoom;
    [Tooltip("The most a player can zoom in to the game world.")]
    public float ZoomMax;
    [Tooltip("The furthest point a player can zoom back from the game world.")]
    public float ZoomMin;
    [Tooltip("How fast the camera rotates")]
    public float RotationSpeed;

    //Camera specific variables
    private Camera _actualCamera;
    private Vector3 _cameraPositionTarget;
    void Start()
    {
        //Store a reference to the camera rig
        _actualCamera = GetComponentInChildren<Camera>();

        //Set the rotation of the camera based on the CameraAngle property
        _actualCamera.transform.rotation = Quaternion.AngleAxis(CameraAngle, Vector3.right);

        //Set the position of the camera based on the look offset, angle and default zoom properties. 
        //This will make sure we're focusing on the right focal point.
        CurrentZoom = DefaultZoom;
        _actualCamera.transform.position = _cameraPositionTarget;

        //Set the initial rotation value
        _rotationTarget = transform.rotation.eulerAngles;
    }

    //Movement variables
    [Header("Movement Settings")]
    [SerializeField] private float MoveTargetSpeed = 8;
    [SerializeField] private float MoveSpeed = 4;
    private Vector3 _moveTarget;
    private Vector3 _moveDirection;
    private float _raiseDirection;
    /// <summary>
    /// Sets the direction of movement based on the input provided by the player
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        //Read the input value that is being sent by the Input System
        Vector2 value = context.ReadValue<Vector2>();

        //Store the value as a Vector3, making sure to move the Y input on the Z axis.
        _moveDirection = new Vector3(value.x, 0, value.y);
    }

    public void OnRaise(InputAction.CallbackContext context)
    {
        //Read the input value that is being sent by the Input System
        float value = context.ReadValue<float>();

        //Store the value as a float
        _raiseDirection = value;
    }

    private void FixedUpdate()
    {
        //Increment the new move Target position of the camera
        _moveTarget += (transform.forward * _moveDirection.z + transform.right *
            _moveDirection.x + transform.up * _raiseDirection) * Time.fixedDeltaTime * MoveTargetSpeed;
    }

    private void LateUpdate()
    {
        //Lerp  the camera to a new move target position
        transform.position = Vector3.Lerp(transform.position, _moveTarget, Time.deltaTime * MoveSpeed);

        //Move the _actualCamera's local position based on the new zoom factor
        _actualCamera.transform.localPosition = Vector3.Lerp(_actualCamera.transform.localPosition,
            _cameraPositionTarget, Time.deltaTime * _zoomSpeed);

        //Set the target rotation based on the mouse delta position and our rotation speed
        _rotationTarget.x += _mouseDelta.x * Time.deltaTime * RotationSpeed;
        _rotationTarget.y -= _mouseDelta.y * Time.deltaTime * RotationSpeed;
        _rotationTarget.x = Mathf.Repeat(_rotationTarget.x, 360);
        _rotationTarget.y = Mathf.Clamp(_rotationTarget.y, -maxYAngle, maxYAngle);

        //Quaternion.AngleAxis(_mouseDelta.x * Time.deltaTime * RotationSpeed, Vector3.up) * Quaternion.AngleAxis(_mouseDelta.y * Time.deltaTime * RotationSpeed, Vector3.right);

        //Slerp the camera rig's rotation based on the new target
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_rotationTarget.y, _rotationTarget.x, 0), Time.deltaTime * InternalRotationSpeed);
    }

    //Zoom variables
    private float _currentZoomAmount;
    public float CurrentZoom
    {
        get => _currentZoomAmount;
        private set
        {
            _currentZoomAmount = value;
            UpdateCameraTarget();
        }
    }
    [Header("Zoom Settings")]
    [SerializeField] private float _zoomSpeed = 3;
    /// <summary>
    /// Calculates a new position based on various properties
    /// </summary>
    private void UpdateCameraTarget()
    {
        _cameraPositionTarget = (Vector3.up * LookOffset) +
            (Quaternion.AngleAxis(CameraAngle, Vector3.right) * Vector3.back) * _currentZoomAmount;
    }

    /// <summary>
    /// Sets the logic for zooming in and out of the level. Clamped to a min and max value.
    /// </summary>
    /// <param name="context"></param>
    public void OnZoom(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
        {
            return;
        }
        // Adjust the current zoom value based on the direction of the scroll - this is clamped to our zoom min/max. 
        CurrentZoom = Mathf.Clamp(_currentZoomAmount - context.ReadValue<Vector2>().y, ZoomMax, ZoomMin);
    }

    //Rotation variables
    private bool _rightMouseDown = false;
    [Header("Rotation Settings")]
    [SerializeField] private float InternalRotationSpeed = 3;
    [SerializeField] private float maxYAngle = 80f;
    private Vector3 _rotationTarget;
    private Vector2 _mouseDelta;
    /// <summary>
    /// Sets whether the player has the right mouse button down
    /// </summary>
    /// <param name="context"></param>
    public void OnRotateToggle(InputAction.CallbackContext context)
    {
        _rightMouseDown = context.ReadValue<float>() == 1;
    }

    /// <summary>
    /// Sets the rotation target quaternion if the right mouse button is pushed when the player is 
    /// moving the mouse
    /// </summary>
    /// <param name="context"></param>
    public void OnRotate(InputAction.CallbackContext context)
    {
        // If the right mouse is down then we'll read the mouse delta value. If it is not, we'll clear it out.
        // Note: Clearing the mouse delta prevents a 'death spin' 
        //from occurring if the player flings the mouse really fast in a direction.
        _mouseDelta = _rightMouseDown ? context.ReadValue<Vector2>() : Vector2.zero;
    }
}
