using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Killable))]
public class Choppable : MonoBehaviour {
    public int _value = 2;

    //TODO: resource packet instead of ints
    //returns resource gains
    public int GetChopped(int power)
    {
        var killable = GetComponent<Killable>();
        if (!killable.IsDead())
        {
            return 0;
        }
            
        if(killable.Damage(power))
        {
            return _value;
        }
        return 0;
    }

    // Use this for initialization
    void Start () {
       
	}
	
    void Awake()
    {
        //GetComponent<Killable>().OnDeath += Death;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
