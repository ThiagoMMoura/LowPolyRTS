using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(UnityStandardAssets.Characters.ThirdPerson.AICharacterControl))]
public class Movel : Unidade, IColetor {

    public int velocidadeDeslocamento;
    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl _characterController;
    private GameObject _destino;
    private float _lastStoppingDistance;
    public int unidadesColetadasPorSegundo;
    public Deposito[] sacolas;

    public Deposito[] depositos
    {
        get
        {
            return this.sacolas;
        }
    }

    public int UnidadesColetadasPorSegundo
    {
        get
        {
            return unidadesColetadasPorSegundo;
        }
    }

    public bool IsColetor()
    {
        return sacolas.Length > 0;
    }

    // Use this for initialization
    internal override void Start()
    {
        base.Start();
        _characterController = GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        _lastStoppingDistance = GetComponentInChildren<NavMeshAgent>().stoppingDistance;
        _destino = new GameObject();
        _destino.name = "Ir Até";
        _destino.transform.localScale.Set(0, 0, 0);
        _destino.transform.position = objUnidade.transform.position;
        _characterController.target = _destino.transform;
    }

    // Update is called once per frame
    internal override void Update()
    {
        base.Update();
        
        if (Input.GetButtonUp("Fire2"))
        {
            print("Fire2");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //Pontos da colisão...
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Unidade unidadeDestino = hit.transform.GetComponent<Unidade>();
                FonteRecurso fonteRecurso = hit.transform.GetComponent<FonteRecurso>();
                StopAllCoroutines();
                if (fonteRecurso != null)
                {
                    StartCoroutine(IniciarColetaRecurso(fonteRecurso));
                    print("inicio coleta");
                }
                else if (unidadeDestino != null)
                {
                    StartCoroutine(MoverPara(unidadeDestino.transform));
                    print("Mover para unidade");
                }
                else
                {
                    _destino.transform.position = hit.point;
                    _characterController.agent.stoppingDistance = 0;
                    StartCoroutine(MoverPara(_destino.transform));
                }
            }
        }
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

    public IEnumerator IniciarColetaRecurso(IRecurso fonte)
    {
        if (IsColetor())
        {
            if(TipoAceito(fonte.Tipo))
            {
                while (!fonte.EstaVazio)
                {
                    yield return StartCoroutine(MoverPara(fonte.transform));
                    while (!EstaCheio(fonte.Tipo))
                    {
                        if (fonte.EstaVazio) { print("Fonte vazia"); break; }
                        yield return new WaitForSeconds(1);
                        ColherRecurso(fonte);
                    }
                    IDeposito depositoProximo = ControlePartida.ObterJogador(IdJogador).ObterDepositoRecursoMaisProximo(fonte.Tipo,transform.position);
                    if (depositoProximo == null)
                    {
                        print("Parando IniciarColetaRecurso");
                        StopAllCoroutines();
                    }
                    yield return StartCoroutine(MoverPara(depositoProximo.transform));
                    Deposito saco = Sacola(fonte.Tipo);
                    saco.UsarRecurso(depositoProximo.DepositarRecurso(saco.QuantidadeAtual));
                }
            }
        }
    }

    public bool TipoAceito(TipoRecurso tipo)
    {
        for(int i = 0; i < sacolas.Length; i++)
        {
            if(sacolas[i].Tipo == tipo)
            {
                return true;
            }
        }
        return false;
    }

    public int DepositarRecurso(int quantidade, TipoRecurso tipo)
    {
        throw new NotImplementedException();
    }

    public bool EstaCheio(TipoRecurso tipo)
    {
        for(int i =0;i < sacolas.Length; i++)
        {
            if (sacolas[i].isTipoAceito(tipo))
            {
                return sacolas[i].EstaCheio;
            }
        }
        return true;
    }

    private Deposito Sacola(TipoRecurso tipo)
    {
        for(int i = 0; i < sacolas.Length; i++)
        {
            if (sacolas[i].isTipoAceito(tipo))
            {
                return sacolas[i];
            }
        }
        return null;
    }

    public int ColherRecurso(IRecurso fonte)
    {
        if (!fonte.EstaVazio)
        {
            Deposito sacola = Sacola(fonte.Tipo);
            if(sacola.CapacidadeDisponivel > unidadesColetadasPorSegundo)
            {
                return sacola.DepositarRecurso(fonte.Colher(unidadesColetadasPorSegundo));
            }
            else
            {
                return sacola.DepositarRecurso(fonte.Colher(sacola.CapacidadeDisponivel));
            }
        }
        return 0;
    }
}
