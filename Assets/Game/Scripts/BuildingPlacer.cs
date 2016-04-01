using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class BuildingPlacer : MonoBehaviour {

    private static GameObject _building;
    private static int _buildingId;
    private static Villager _villager;

    public static bool IsPlacing
    {
        get { return _building != null; }
    }
	
	public static void Create(int id, Villager villager)
    {
        _buildingId = id;
        _villager = villager;
        DestroyCurrent();
        InstantiateNewBuilding(string.Empty);//Incompleto
    }

    public static void DestroyCurrent()
    {
        if(_building != null)
        {
            Destroy(_building);
            _building = null;
        }
    }

    private static void InstantiateNewBuilding(string path)
    {
        //buscar a construção no caminho passado
        _building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _building.GetComponent<BoxCollider>().enabled = false;

    }

    private static void PlaceBuilding()
    {
        GameObject newBuilding = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newBuilding.transform.position = _building.transform.position;
        StaticEntityProperties properties = EntitiesHolder.LoadEntityById(_buildingId) as StaticEntityProperties;
        Construction c = newBuilding.AddComponent<Construction>();
        c.OnCreated(new string[1] { properties.Id.ToString() });
        _villager.ActionCallback(c);
        DestroyCurrent();
    }

	void Update () {
        if (IsPlacing)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(r.origin,r.direction,out hit))
            {
                _building.transform.position = hit.point;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                DestroyCurrent();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                PlaceBuilding();
            }
        }
	}
}
