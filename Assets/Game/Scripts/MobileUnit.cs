using UnityEngine;
using System.Collections;

public class MobileUnit : BaseUnit {

    public new MobileUnitProperties properties;
	// Use this for initialization
	internal override void Start () {
        base.Start();
        properties = new MobileUnitProperties();
        properties.movementSpeed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (IsSelected)
        {
            EntityProperties[] entitiesAvailableOnThisUnit = EntitiesHolder.LoadEntitiesAvailableOnId(base.id);
            for(int i = 0;i < entitiesAvailableOnThisUnit.Length; i++)
            {
                EntityProperties current = entitiesAvailableOnThisUnit[i];
                if(GUI.Button(new Rect(0, 40 * i, 400, 40), current.Name + ", " + current.Description))
                {
                    BuildingPlacer.Create(current.Id, (this as Villager));
                }
            }
        }
    }

    internal IEnumerator MoveTo(Vector3[] path)//paht = caminho
    {
        for(int i =0;i< path.Length; i++)
        {
            Vector3 direction = Vector3.zero;
            do
            {
                direction = (path[i] - transform.position);
                MovementCallback(direction.normalized);
                yield return null;
            } while (direction.sqrMagnitude > 0.1f);
        }
    }

    public void MovementCallback(Vector3 direction)
    {
        transform.position += direction * properties.movementSpeed * Time.deltaTime;
    }

    public override void ActionCallback(Vector3 target)
    {
        StartCoroutine(MoveTo(new Vector3[1] { target }));
    }
}
