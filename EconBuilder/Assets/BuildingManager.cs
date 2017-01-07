using UnityEngine;
using System.Collections;
using System;

public class BuildingManager : MonoBehaviour {

    public GameObject SelectedBuilding;

    public bool isPlacing = false;
    GameObject m_Building;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update()
    {
        //TODO: state machine logic bleh
        if(isPlacing)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                StopPlacingHouse();
            }   
            else if (m_Building != null && Input.GetMouseButtonDown(0) && m_Building.GetComponent<BuildingPlacement>().IsValidLocation())
            {
                PlaceHouse();
            }
        }
        else //not placing
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                StartPlacingHouse();
            }
        }
	}    

    void PlaceHouse()
    {
        m_Building.GetComponent<BuildingPlacement>().ExitBuildingPlacement();
        m_Building = null;
        isPlacing = false;
    }
    
    void StartPlacingHouse()
    {        
        RaycastHit hitInfo;
        if(TerrainManager.GetGroundHitLocation(out hitInfo))
        { 
            // TODO: better rotation
            m_Building = (GameObject)Instantiate(SelectedBuilding, hitInfo.point, transform.rotation);
            m_Building.GetComponent<BuildingPlacement>().enabled = true;
            isPlacing = true;
        }
    }

    void StopPlacingHouse()
    {
        m_Building.GetComponent<BuildingPlacement>().ExitBuildingPlacement();
        isPlacing = false;
        Destroy(m_Building);
        m_Building = null;
    }    

    
}