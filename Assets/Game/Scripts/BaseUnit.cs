using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour {
    public Projector projector;
    private bool _isSelected;
    public UnitProperties properties;
    public int id;

	// Use this for initialization
	internal virtual void Start () {
        properties.Initialize();
        UnitController.AddBaseUnitToList(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            if (value)
            {
                projector.enabled = true;
            }
            else
            {
                projector.enabled = false;
            }
            _isSelected = value;
        }
    }

    public virtual void ActionCallback(Vector3 target){}

    public virtual void ActionCallback(ResourceRoot target) {}

    public virtual void ActionCallback(Construction target) { }

    public virtual void OnCreated(string[] arguments) {}
}
