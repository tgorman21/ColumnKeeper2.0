using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowType : MonoBehaviour
{
   
    public enum TypeOfArrow { Regular, Fire, Ice, MeteorShower, Lightning, Rain, Heal, Target };

    public TypeOfArrow typeOfArrow;
    public float damage;
    public TrailRenderer trail;
    private void Start()
    {

        if (GetComponentInChildren<TrailRenderer>() != null)
        {
            trail = GetComponentInChildren<TrailRenderer>();
            trail.enabled = false;
        }
    }
}
