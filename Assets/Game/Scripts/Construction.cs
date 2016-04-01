using UnityEngine;
using System.Collections;

public class Construction : StaticUnit {

    private int _id;
    private int _currentHp;
    private int _maxHp;

    public override void OnCreated(string[] arguments)
    {
        _id = int.Parse(arguments[0]);
        _maxHp = EntitiesHolder.LoadEntityById(_id).hp;
    }

    public bool IsDone
    {
        get { return _currentHp >= _maxHp; }
    }

    public void Build(int hp)
    {
        _currentHp += hp;
        //renderer.material.color = Color.red;
        transform.localScale = Vector3.one * (_currentHp /(float) _maxHp);
        if(_currentHp >= _maxHp)
        {
            _currentHp = _maxHp;
            OnBuildDone();
        }
    }

    private void OnBuildDone()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = transform.position;
        StaticEntityProperties props = EntitiesHolder.LoadEntityById(_id) as StaticEntityProperties;
        (UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(go, "Assets/Scripts/Construction.cs (38,10)", props.scriptInfo.script) as BaseUnit).OnCreated(props.scriptInfo.arguments);
        Destroy(gameObject);
    }
}
