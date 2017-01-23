using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Interact : iAction {
    public TargettingArc _targetter;
    public GameObject _actor;
    public Interact( GameObject actor, TargettingArc targetter)
    {
        _actor = actor;
        _targetter = targetter;
    }

    public void Execute()
    {
        var target = Targetter.GetClosest(_actor.transform.position, GetTargets());
        if (target != null)
        {
            target.GetComponent<Interactable>().Interact();
        }
    }

    private IEnumerable<GameObject> GetTargets()
    {
        return _targetter.GetTargets(_actor.transform.position, _actor.transform.forward, targetType());
    }

    public bool HasValidTarget()
    {
        foreach (var target in GetTargets())
        {
            return true;
        }
        return false;
    }

    public Type targetType()
    {
        return typeof(Interactable);
    }
}
