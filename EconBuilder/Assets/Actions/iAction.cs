using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IAction {
    void Execute(GameObject _actor);
    bool HasValidTarget(GameObject _actor);
    System.Type targetType();
}
