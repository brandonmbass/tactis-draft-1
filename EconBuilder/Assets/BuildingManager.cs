using UnityEngine;
using System.Collections;
using System;

public class BuildingManager : MonoBehaviour {

    public GameObject SelectedBuilding;
    public readonly Color DefaultColor = new Color(.5f, .5f, .5f, 1f);
    public readonly Color ValidSpotColor = new Color(.5f, 2f, .5f, .3f);
    public readonly Color InvalidSpotColor = new Color(2f, .5f, .5f, .3f);

    bool isPlacing = false;
    GameObject m_Building;
    LayerMask terrainLayerMask;
    LayerMask contructLayerMask;
    // Use this for initialization
    void Start () {
	    terrainLayerMask = 1 << LayerMask.NameToLayer("Terrain");
        contructLayerMask = 1 << LayerMask.NameToLayer("Construct");
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
            else if (m_Building != null)
            {
                // We're placing a building 
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceHouse();
                }
                else
                {
                    // Update color (validity) and location based on mouse position
                    UpdateBuildingGhost();
                }
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
        var collider = m_Building.AddComponent<BoxCollider>();
        collider.size = new Vector3(4f, 4f, 4f);
        collider.center = new Vector3(0f, 2f, 0f);
        collider.isTrigger = true;
        m_Building.layer = LayerMask.NameToLayer("Construct");

        foreach (var r in m_Building.GetComponentsInChildren<MeshRenderer>())
        {
            StandardShaderUtils.ChangeRenderMode(r.material, StandardShaderUtils.BlendMode.Opaque);
            r.material.color = DefaultColor;
        }

        m_Building = null;
        isPlacing = false;
    }
    
    void StartPlacingHouse()
    {
        isPlacing = true;
        RaycastHit hitInfo;
        if(GetGroundHitLocation(out hitInfo))
        { 
            // TODO: better rotation
            m_Building = (GameObject)Instantiate(SelectedBuilding, hitInfo.point, transform.rotation);
            UpdateBuildingGhost();
        }
    }

    void StopPlacingHouse()
    {
        isPlacing = false;
        Destroy(m_Building);
        m_Building = null;
    }

    bool GetGroundHitLocation(out RaycastHit hitInfo)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hitInfo,Mathf.Infinity, terrainLayerMask);
    }

    void UpdateBuildingGhost()
    {
        RaycastHit hitInfo;
        var validLocation = GetGroundHitLocation(out hitInfo);
        m_Building.transform.position = hitInfo.point;
        if (validLocation)
        {
            validLocation = !Physics.CheckBox(hitInfo.point + new Vector3(0f, 2f, 0f), new Vector3(4f, 4f, 4f),m_Building.transform.rotation, contructLayerMask, QueryTriggerInteraction.Collide);
        }
        foreach (var r in m_Building.GetComponentsInChildren<MeshRenderer>())
        {
            StandardShaderUtils.ChangeRenderMode(r.material, StandardShaderUtils.BlendMode.Transparent);
            r.material.color = validLocation ? ValidSpotColor : InvalidSpotColor;
        }
    }
}

public static class StandardShaderUtils
{
    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }

    public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }

    }
}
