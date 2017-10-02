using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Chop : IAction {
    public TargettingArc _targetter;
    public int _power;    
    public AudioSource chopAudio;

    public Chop(int power, TargettingArc targetter)
    {
        _targetter = targetter;
        _power = power;

        // TODO: store audio clips somewhere globally accessible
        chopAudio = GameObject.Find("_GLOBAL_DATA_").GetComponent<AudioSource>();
    }
    public Type targetType()
    {
        return typeof(Choppable);
    }

    public void Execute(GameObject _actor)
    {
        var target = Targetter.GetClosest( _actor.transform.position, GetTargets(_actor));
        if(target != null)
        {
            //AudioSource.PlayClipAtPoint(chopAudio.clip, _actor.transform.position);
            chopAudio.Play();

            var resourceAmount = target.GetComponent<Choppable>().GetChopped(_power);
            if(resourceAmount > 0)
            {
                Debug.Log("Collected " + resourceAmount + "inches of wood.");
            }
        }
    }
    private IEnumerable<GameObject> GetTargets(GameObject _actor)
    {
        var position = _actor.transform.position;
        var forward = _actor.transform.forward;
        var type = targetType();
       return _targetter.GetTargets(position, forward, type);
    }

    public bool HasValidTarget(GameObject _actor)
    {
        foreach(var target in GetTargets(_actor))
        {
            return true;
        }
        return false;
    }
}
