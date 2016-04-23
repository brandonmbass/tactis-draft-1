using UnityEngine;
using System.Collections;

public class Surface : MonoBehaviour {
    public ArrayList neighbors = new ArrayList();
    GameObject indicator;

    public void Start()
    {
        indicator = transform.GetChild(0).gameObject;
        transform.rotation = Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
        indicator.GetComponent<MeshRenderer>().enabled = false;
    }

    public void addNeighbor(Surface newNeighbor)
    {
        Link link = new Link(this, newNeighbor);
        neighbors.Add(link);

    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        indicator.GetComponent<MeshRenderer>().enabled = true;
    }

    void OnMouseExit()
    {
        indicator.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnMouseClick()
    {
        
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