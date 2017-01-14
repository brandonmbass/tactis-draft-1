using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetter{
    public static GameObject GetClosest(Vector3 origin, IEnumerable<GameObject> candidates)
    {
        var shortestDistance = float.PositiveInfinity;
        Collider closest = null;
        foreach (var target in candidates)
        {
            var collider = target.GetComponent<Collider>();
            if (collider != null)
            {
                var closestPoint = collider.ClosestPointOnBounds(origin);
                var candidateDistance = Vector3.Distance(closestPoint, origin);
                if (candidateDistance <= shortestDistance)
                {
                    shortestDistance = candidateDistance;
                    closest = collider;
                }
            }
        }
        return closest.gameObject;
    }
}
