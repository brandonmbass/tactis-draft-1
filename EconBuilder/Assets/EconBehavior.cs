using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconBehavior : MonoBehaviour {
    private Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();
    protected T Get<T>(string gameObject = null)
    {
        if (gameObject == null)
        {
            return this.GetComponent<T>();
        }

        if (!gameObjects.ContainsKey(gameObject))
        {
            gameObjects[gameObject] = GameObject.Find(gameObject);
        }

        return gameObjects[gameObject].GetComponent<T>();
    }
}
