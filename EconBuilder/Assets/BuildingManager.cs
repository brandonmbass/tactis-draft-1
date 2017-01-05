using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

    public GameObject SelectedBuilding;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.B))
        {            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                var obj = hitInfo.collider.gameObject;
                // TODO: Don't use name
                // TODO: handle multiple hits
                if (obj.name == "Terrain")
                {
                    // TODO: better rotation
                    Instantiate(SelectedBuilding, hitInfo.point, transform.rotation);
                }
            }
        }
	}
}
