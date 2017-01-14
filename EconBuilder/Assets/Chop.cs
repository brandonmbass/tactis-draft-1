using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Chop : iAction {
    public TargettingArc _targetter;
    public int _power;
    public GameObject _actor;

    public Chop(GameObject actor, int power, TargettingArc targetter)
    {
        _targetter = targetter;
        _power = power;
        _actor = actor;
    }
    public Type targetType()
    {
        return typeof(Choppable);
    }

    public void Execute()
    {
        var target = Targetter.GetClosest( _actor.transform.position, GetTargets());
        if(target != null)
        {
            var resourceAmount = target.GetComponent<Choppable>().GetChopped(_power);
            if(resourceAmount > 0)
            {
                Debug.Log("Collected " + resourceAmount + "inches of wood.");
            }
        }
    }
    private IEnumerable<GameObject> GetTargets()
    {
        var position = _actor.transform.position;
        var forward = _actor.transform.forward;
        var type = targetType();
       return _targetter.GetTargets(position, forward, type);
    }

    public bool HasValidTarget()
    {
        foreach(var target in GetTargets())
        {
            return true;
        }
        return false;
    }
}
