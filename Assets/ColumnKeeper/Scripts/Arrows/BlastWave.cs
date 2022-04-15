using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlastWave : MonoBehaviour
{
    public int pointsCount;
    public float maxRadius;
    public float speed;
    public float startWidth;
    private FireArrow fireArrow;
    public float force;

    private LineRenderer lineRenderer;
    private void Start()
    {
        fireArrow = GetComponentInParent<FireArrow>();
    }
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = pointsCount + 1;
    }
    public IEnumerator Blast()
    {
        float currentRadius = 0f;


        while(currentRadius < maxRadius)
        {
            currentRadius += Time.deltaTime * speed;
            lineRenderer.enabled = true;
            Draw(currentRadius);
            Damage(currentRadius);
            yield return null;
        }
        lineRenderer.enabled = false;
    }
    private void Damage(float currentRadius)
    {
        Collider[] hittingObjects = Physics.OverlapSphere(transform.position, currentRadius);
        
        foreach (Collider col in hittingObjects)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (!rb)
                    continue;
                //rb.isKinematic = false;
                col.GetComponent<NavMeshAgent>().speed = 0;
                Vector3 direction = (col.transform.position - transform.position).normalized;
                rb.AddForce(direction * force, ForceMode.Impulse);
                col.GetComponent<Enemy>().impact = true;
                col.GetComponent<Enemy>().FireDamage(fireArrow.impactDamage, fireArrow.decayDamage);
            }
        }

    }
    private void Draw(float currentRadius)
    {
        float angleBetweenPoints = 360f / pointsCount;

        for(int i =0; i <= pointsCount; i++)
        {
            float angle = i * angleBetweenPoints * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }
        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);
    }


}
