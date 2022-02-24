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

        //Sets name of Float for damage arrows
        switch (typeOfArrow)
        {
            case TypeOfArrow.Fire:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
            case TypeOfArrow.Ice:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
            case TypeOfArrow.MeteorShower:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
            case TypeOfArrow.Lightning:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
            case TypeOfArrow.Rain:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
            case TypeOfArrow.Regular:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
            case TypeOfArrow.Target:
                PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);
                break;
        }
    }
}
