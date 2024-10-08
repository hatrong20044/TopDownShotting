using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    private float m_curDamage;

    public float CurDamage { get => m_curDamage; private  set => m_curDamage = value; }
}
