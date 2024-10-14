using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollectable :Collectable
{

    public override void Trigger()
    {
        GameManager.Ins.CurLife += m_bonus;
    }

}
