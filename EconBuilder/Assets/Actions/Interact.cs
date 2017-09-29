using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Interact : IAction {
    public TargettingArc _targetter;
    public Interact(TargettingArc targetter)
    {
        _targetter = targetter;
    }

    public void Execute(GameObject _actor)
    {
        var target = Targetter.GetClosest(_actor.transform.position, GetTargets(_actor));
        if (target != null)
        {
            target.GetComponent<Interactable>().Interact();
        }
    }

    private IEnumerable<GameObject> GetTargets(GameObject _actor)
    {
        return _targetter.GetTargets(_actor.transform.position, _actor.transform.forward, targetType());
    }

    public bool HasValidTarget(GameObject _actor)
    {
        Debug.Log("Has valid target");
        foreach (var target in GetTargets(_actor))
        {
            Debug.Log("Target");
            return true;
        }
        return false;
    }

    public Type targetType()
    {
        return typeof(Interactable);
    }
}
