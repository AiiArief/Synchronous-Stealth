using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoredStatusEffect
{
    public Action effectAction;
    public int effectTurnCountdown = -1;
}

public class StoredStatusEffectCustom : StoredStatusEffect
{
    public StoredStatusEffectCustom(Action customEffectAction)
    {
        effectAction = customEffectAction;
    }
}

// auto skip
// auto skip delay
// disable move
// disable shoot
