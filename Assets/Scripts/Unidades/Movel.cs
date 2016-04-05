using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityStandardAssets.Characters.ThirdPerson.AICharacterControl))]
public class Movel : Unidade {

    public int velocidadeDeslocamento;
    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl _characterController;
    private GameObject _destino;
    private float _lastStoppingDistance;

    // Use this for initialization
    internal override void Start()
    {
        base.Start();
        _characterController = unidade.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        _destino = new GameObject();
        _destino.transform.localScale.Set(0, 0, 0);
        _destino.transform.position = unidade.transform.position;
        _lastStoppingDistance = _characterController.agent.stoppingDistance;
    }

    // Update is called once per frame
    internal override void Update()
    {
        base.Update();
        
        if (Input.GetButtonUp("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //Pontos da colisão...
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                _destino.transform.position = hit.point;
                _characterController.agent.stoppingDistance = 0;
                MoverPara(_destino.transform);
            }
        }

        if (_characterController.target != _destino.transform )
        {
            _characterController.agent.stoppingDistance = _lastStoppingDistance;
        }
    }

    public void MoverPara(Transform target)
    {
        _characterController.SetTarget(target);
    }

}
