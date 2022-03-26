using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace UnityEngine.XR.Interaction.Toolkit
{
    
    public class StunPlayer : MonoBehaviour
    {
        [SerializeField]ActionBasedContinuousMoveProvider moveProvider;
        [SerializeField] SprintPlayer sprintPlayer;
        [SerializeField] float stunDuration;
        float initialSpeed;
        [Header("Dev Tool")]
        [SerializeField] bool stun;
        // Start is called before the first frame update
        void Start()
        {
            initialSpeed = moveProvider.moveSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (stun)
            {
                Stun();
            }
        }
        public void Stun()
        {
            stun = false;

            moveProvider.moveSpeed = 1;
            sprintPlayer.enabled = false;
            StartCoroutine(UnStun(stunDuration));
        }
        IEnumerator UnStun(float t)
        {
            yield return new WaitForSeconds(t);
            moveProvider.moveSpeed = initialSpeed;
            sprintPlayer.enabled = true;
        }
    }
}