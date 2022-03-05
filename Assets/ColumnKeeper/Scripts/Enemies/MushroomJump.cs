using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MushroomJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpForce;
    NavMeshAgent agent;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(rb.velocity);
        if(rb.velocity == Vector3.zero)
        {
            grounded = true;
            agent.enabled = true;
        }
        if (grounded)
        {
            StartCoroutine(WaitToJump());
            
        }
    }
    IEnumerator WaitToJump()
    {
        yield return new WaitForSeconds(0.5f);
        agent.enabled = false;
        rb.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
        rb.AddForce(transform.forward * 2 * Time.deltaTime, ForceMode.VelocityChange);
        //rb.velocity += Vector3.right * jumpForce / 12;
        //grounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            agent.enabled = true;
            grounded = true;
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            agent.enabled = false;
            grounded = false; 
        }
    }

}
