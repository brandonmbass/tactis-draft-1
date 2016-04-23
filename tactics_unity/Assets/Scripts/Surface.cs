using UnityEngine;
using System.Collections;
using System;

public class Surface : MonoBehaviour {
    public ArrayList neighbors = new ArrayList();
    public Selector selector;

    public void Start()
    {
        transform.rotation = Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
        selector = GameObject.FindObjectOfType<Selector>();
    }

    public void addNeighbor(Surface newNeighbor)
    {
        Link link = new Link(this, newNeighbor);
        neighbors.Add(link);
    }

    void OnMouseEnter() { selector.surfaceMouseEnter(this); }

    void OnMouseExit() { selector.surfaceMouseExit(this); }

    void OnMouseDown() {
        Debug.Log("MOUSE CLICKED");
        selector.surfaceClick(this); }
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