using UnityEngine;
using System.Collections;
using System;

public class Killable : MonoBehaviour {
    public int _life;
    public int _damage;
    public bool _isDead;
    public delegate void deathCallback();
    //public deathCallback OnDeath; 

    public bool IsDead()
    {
        return _isDead;
    }

    public void Kill()
    {
        _damage = _life;
        _isDead = true;
        Destroy(gameObject);
    }

    //TODO: better way?
    //returns true if killed
    public bool Damage(int power)
    {
        _damage += power;
        if (_damage >= _life)
        {
            Kill();
            return true;
        }
        return false;
    }

    public void ResetDamage()
    {
        _damage = 0;
    }

    public void Revive()
    {
        _damage = 0;
        _isDead = false;
    }
}
