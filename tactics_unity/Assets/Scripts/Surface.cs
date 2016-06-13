using UnityEngine;
using System.Collections;
using System;

public class Surface : MonoBehaviour {
    public ArrayList neighbors = new ArrayList();
    public OpenState selector;
    Unit currentUnit;

    public void Start()
    {
        
    }

    public void addNeighbor(Surface newNeighbor)
    {
        Link link = new Link(this, newNeighbor);
        neighbors.Add(link);
    }

    public void AddUnit(Unit unit)
    {
        unit.transform.position = transform.position;
        unit.SetSurface(this);
        currentUnit = unit;
    }

    public Unit RemoveUnit()
    {
        Unit unit = currentUnit;
        currentUnit = null;
        return unit;
    }

    public Unit GetUnit()
    {
        return currentUnit;
    }
}

public class Link
{
    public Link(Surface from, Surface to)
    {
        this.from = from;
        this.to = to;
    }
    public Surface from;
    public Surface to;
}