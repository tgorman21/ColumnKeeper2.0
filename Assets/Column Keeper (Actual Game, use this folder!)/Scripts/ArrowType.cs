﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowType : MonoBehaviour
{
   
    public enum TypeOfArrow { Regular, Fire, Ice, Hypno, Lightning, Rain, Heal };

    public TypeOfArrow typeOfArrow;
    public float damage;
}