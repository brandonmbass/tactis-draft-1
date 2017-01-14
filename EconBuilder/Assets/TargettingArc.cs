using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargettingArc{
    public float _arc;
    public float _range;
    public TargettingArc(float arc, float range)
    {
        _arc = arc;
        _range = range;
    }

    public IEnumerable<GameObject> GetTargets(Vector3 origin, Vector3 facing, System.Type type)
    {
        var colliders = Physics.OverlapSphere(origin, _range);
        foreach (var collider in colliders)
        {
            if (type != null)
                if (collider.GetComponent(type) == null)
                    continue;
            var targetPosition = collider.transform.position;
            var position = origin;

            var targetDirection = targetPosition - position;
            targetDirection.y = 0;
            var facing2d = facing;
            facing2d.y = 0;

            float angle = Vector3.Angle(targetDirection, facing2d);
            if (angle < _arc)
            {
                yield return collider.gameObject;
            }
        }
    }
}
