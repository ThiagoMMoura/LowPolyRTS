using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(AICharacterControl))]
public class Movel : MonoBehaviour {

    public float velocidade;

    private AICharacterControl _characterController;
    private GameObject _destino;
    private float _lastStoppingDistance;

    // Use this for initialization
    void Start()
    {
        IMovel movel = GetComponent<IMovel>();
        if(movel != null)
        {
            velocidade = movel.velocidade;
        }
        _characterController = GetComponent<AICharacterControl>();
        _lastStoppingDistance = GetComponentInChildren<NavMeshAgent>().stoppingDistance;
        _destino = new GameObject();
        _destino.name = "Ir Até";
        _destino.transform.localScale.Set(0, 0, 0);
        _destino.transform.position = gameObject.transform.position;
        _characterController.target = _destino.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonUp("Fire2"))
        //{
        //    print("Fire2");
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit; //Pontos da colisão...
        //    if (Physics.Raycast(ray.origin, ray.direction, out hit))
        //    {
        //        Unidade unidadeDestino = hit.transform.GetComponent<Unidade>();
        //        FonteRecurso fonteRecurso = hit.transform.GetComponent<FonteRecurso>();
        //        StopAllCoroutines();
        //        if (fonteRecurso != null)
        //        {
        //            //StartCoroutine(IniciarColetaRecurso(fonteRecurso));
        //            print("inicio coleta");
        //        }
        //        else if (unidadeDestino != null)
        //        {
        //            StartCoroutine(MoverPara(unidadeDestino.transform));
        //            print("Mover para unidade");
        //        }
        //        else
        //        {
        //            _destino.transform.position = hit.point;
        //            _characterController.agent.stoppingDistance = 0;
        //            StartCoroutine(MoverPara(_destino.transform));
        //        }
        //    }
        //}
        //print("Distância: " + _characterController.agent.remainingDistance+ " Destino: "+ _characterController.target.position.ToString()+" Posição: "+transform.position.ToString());
        if (_characterController.target != _destino.transform)
        {
            _characterController.agent.stoppingDistance = _lastStoppingDistance;
        }
    }

    public IEnumerator MoverPara(Transform target)
    {
        _destino.transform.position = target.position;
        _characterController.SetTarget(_destino.transform);
        yield return new WaitForSeconds(.1f);
        do
        {
            yield return new WaitForEndOfFrame();
            if (_characterController.target.position != target.position)
            {
                print("break");
                break;
            }
        } while (_characterController.agent.remainingDistance > _characterController.agent.stoppingDistance);
        _characterController.agent.stoppingDistance = _lastStoppingDistance;
    }

    public IEnumerator MoverQualquerCustoPara(Transform target)
    {
        yield return MoverPara(target);
    }
   
}
