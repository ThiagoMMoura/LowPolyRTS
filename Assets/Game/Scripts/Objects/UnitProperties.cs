using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnitProperties {

    public float totalLife;
    private float _currentLife;

    public void Initialize()
    {
        _currentLife = totalLife;
    }

    public float CurrentLife
    {
        get { return _currentLife; }
    }
}
