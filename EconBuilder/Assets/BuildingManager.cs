using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

    public GameObject SelectedBuilding;
    public readonly Color DefaultColor = new Color(.5f, .5f, .5f, 1f);
    public readonly Color ValidSpotColor = new Color(.5f, 2f, .5f, .3f);
    public readonly Color InvalidSpotColor = new Color(2f, .5f, .5f, .3f);

    GameObject m_Building;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	    if (Input.GetKeyDown(KeyCode.B))
        {
            StartPlacingHouse();
            return;
        }

        if (m_Building != null)
        {
            // We're placing a building 
            if (Input.GetMouseButtonDown(0))
            {
                PlaceHouse();
                return;
            }

            // Update color (validity) and location based on mouse position
            UpdateBuildingGhost();
        }
	}

    void PlaceHouse()
    {
        foreach (var r in m_Building.GetComponentsInChildren<MeshRenderer>())
        {
            StandardShaderUtils.ChangeRenderMode(r.material, StandardShaderUtils.BlendMode.Opaque);
            r.material.color = DefaultColor;
        }

        m_Building = null;
    }

    void UpdateBuildingGhost()
    {
        RaycastHit hitInfo;
        var validLocation = GetGroundHitLocation(out hitInfo);

        // TODO: check if the collision box hits any other collision boxes - that also makes this invalid

        m_Building.transform.position = hitInfo.point;
        foreach (var r in m_Building.GetComponentsInChildren<MeshRenderer>())
        {
            StandardShaderUtils.ChangeRenderMode(r.material, StandardShaderUtils.BlendMode.Transparent);
            r.material.color = validLocation ? ValidSpotColor : InvalidSpotColor;
        }
    }

    void StartPlacingHouse()
    {
        RaycastHit hitInfo;
        if (!GetGroundHitLocation(out hitInfo))
        {
            return;
        }

        // TODO: better rotation
        m_Building = (GameObject)Instantiate(SelectedBuilding, hitInfo.point, transform.rotation);
        UpdateBuildingGhost();
    }

    bool GetGroundHitLocation(out RaycastHit hitInfo)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            var obj = hitInfo.collider.gameObject;
            // TODO: Don't use name
            // TODO: handle multiple hits
            if (obj.name == "Terrain")
            {
                return true;
            }
        }

        return false;
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
