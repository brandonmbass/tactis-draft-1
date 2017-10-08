using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GlobalData {
    static private GameObject managers;

    static public UIManager UIManager { get { return Get<UIManager>(); } }
    
    static private T Get<T>()
    {
        if (managers == null)
        {
            managers = GameObject.Find("_GLOBAL_DATA_/Managers");
        }

        return managers.GetComponent<T>();
    }
}
