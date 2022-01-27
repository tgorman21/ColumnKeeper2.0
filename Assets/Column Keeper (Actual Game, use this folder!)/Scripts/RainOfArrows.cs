using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOfArrows : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] GameObject Flare;
    [SerializeField] private int spawnAmount;
    [SerializeField] private float yPos;

    [SerializeField] private bool RainArrows;
    private float t = 0;

    private void Update()
    {
        if (!RainArrows) return; //////don't do anything below unless raining arrows

        t += Time.deltaTime;
        SpawnArrow();

        //Debug.Log(t);

        if (t > 3) //////once done raining, reset variables
        {
            RainArrows = false;
            t = 0;
        }
    }

    public void Rain()
    {

        RainArrows = true;
        //Debug.Log("Rain");
       
    }
    private void SpawnArrow()
    {
        Flare.SetActive(true);
        float x = Random.Range(-4f, 4f);
        float z = Random.Range(-4f, 4f);
        Vector3 pos = new Vector3(transform.position.x + x, transform.position.y + yPos, transform.position.z + z);
        GameObject arrowInstance = Instantiate(arrow, pos, Quaternion.Euler(90, 0, 0));
        arrowInstance.GetComponent<ArrowType>().damage = GetComponent<ArrowType>().damage;
        arrowInstance.GetComponent<Rigidbody>().freezeRotation = true;
        arrowInstance.GetComponent<Arrow>().launched = true;
        arrowInstance.GetComponent<Arrow>().Rain(2);
    }


}
