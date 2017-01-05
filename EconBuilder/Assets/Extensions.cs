using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static  class Extensions
{
    public static IEnumerable<T> GetComponentsRecursive<T>(this GameObject gameObject)
    {
        return gameObject.GetComponents<T>().Concat(gameObject.GetComponentsInChildren<T>());
    }
}
