using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface iAction {
    void Execute();
    bool HasValidTarget();
}
