using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

    public class SprintPlayer : MonoBehaviour
    {
        XRIDefaultInputActions inputs;
        public float sprintSpeed;
        float defaultSpeed;
        [SerializeField]ActionBasedContinuousMoveProvider moveProvider;
        
        private void Awake()
        {
            inputs = new XRIDefaultInputActions();
            inputs.XRILeftHand.Sprint.performed += tgb => Sprint(sprintSpeed);
            inputs.XRILeftHand.Sprint.canceled += tgb => Sprint(defaultSpeed);
        }
        // Start is called before the first frame update
        void Start()
        {
            defaultSpeed = moveProvider.moveSpeed;
        }
        private void OnEnable()
        {
            inputs.Enable();
        }
        private void OnDisable()
        {
            inputs.Disable();
        }
        // Update is called once per frame
        void Update()
        {

        }
        public void Sprint(float speed)
        {
            moveProvider.moveSpeed = speed;

        }
    }
