using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Chop : iAction {
    public float _arc;
    public float _range;
    public GameObject _actor;

    public void Execute()
    {
        var targets = GetTargets(_arc, _range);
        foreach (var target in targets)
        {
            Vector3.Distance(_actor.transform.position, target.transform.position);
        }
    }

    public bool GetValidTarget()
    {
        foreach(var target in targets)
        {
            if(target.GetComponent<Choppable>() != null)
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerable<GameObject> GetTargets(float arc, float range)
    {
        List<GameObject> targets = new List<GameObject>();
        var colliders = Physics.OverlapSphere(_actor.transform.position, range);

        foreach (var collider in colliders)
        {
            var targetPosition = collider.transform.position;
            var position = _actor.transform.position;

            var targetDirection = targetPosition - position;
            targetDirection.y = 0;
            var facing2d = _actor.transform.forward;
            facing2d.y = 0;

            float angle = Vector3.Angle(targetDirection, facing2d);
            if (angle < arc)
            {
                targets.Add(collider.gameObject);
            }
        }

        return targets;
    }
}
