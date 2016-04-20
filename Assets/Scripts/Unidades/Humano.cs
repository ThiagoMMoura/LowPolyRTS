using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Unidade))]
[RequireComponent(typeof(Mortal))]
[RequireComponent(typeof(Movel))]
[RequireComponent(typeof(Atividade))]
public class Humano : MonoBehaviour,IMortal,IHumano,IMovel {

    private Sexo _sexo;
    private Mortal _mortal;
    private Atividade _atividade;

    public PHumano propriedadesHumano;
    public bool isReprodutor;

    public Sexo sexo
    {
        get{ return propriedadesHumano.sexo; }
    }

    public Mortal mortal
    {
        get { return _mortal; }
    }

    public PHumano propriedades
    {
        get{ return propriedadesHumano; }

        set{ propriedadesHumano = value; }
    }

    int IUnidade.vitalidade
    {
        get
        {
            return propriedadesHumano.vitalidade;
        }
    }

    public int vitalidadeAtual
    {
        get
        {
            return propriedadesHumano.vitalidadeAtual;
        }
    }

    int IUnidade.idJogador
    {
        get
        {
            return propriedadesHumano.idJogador;
        }

        set
        {
            propriedadesHumano.idJogador = value;
        }
    }

    PUnidade IUnidade.propriedades
    {
        get
        {
            return propriedadesHumano;
        }

        set
        {
            propriedadesHumano = value as PHumano;
        }
    }

    int IEntidade.id
    {
        get
        {
            return propriedadesHumano.id;
        }
    }

    public string nome
    {
        get
        {
            return propriedadesHumano.nome;
        }
    }

    public string descricao
    {
        get
        {
            return propriedadesHumano.descricao;
        }
    }

    PEntidade IEntidade.propriedades
    {
        get
        {
            return propriedadesHumano;
        }

        set
        {
            propriedadesHumano = value as PHumano;
        }
    }

    int IMortal.expectativaDeVida
    {
        get
        {
            return propriedadesHumano.expectativaDeVida;
        }
    }

    public float velocidade
    {
        get
        {
            return propriedadesHumano.velocidade;
        }
    }

    public Atividades atividade
    {
        get
        {
            return _atividade.atividade;
        }

        set
        {
            _atividade.atividade = value;
        }
    }

    internal virtual void Start () {
        _mortal = GetComponent<Mortal>();
        _atividade = GetComponent<Atividade>();
    }

    // Update is called once per frame
    internal virtual void Update () {
        
	}

    public virtual void AoEnvelhecer() {}

    public virtual void Danificar(int dano) {}

    public bool EstaDisponivel()
    {
        switch (_atividade.atividade)
        {
            case Atividades.carregando: {
                    return true;
                }
            case Atividades.colhendo:
                {
                    return true;
                }
            case Atividades.correndo:
                {
                    return true;
                }
            case Atividades.crescendo:
                {
                    return false;
                }
            case Atividades.dormindo:
                {
                    return false;
                }
            case Atividades.marchando:
                {
                    return true;
                }
            case Atividades.morrendo:
                {
                    return false;
                }
            case Atividades.plantando:
                {
                    return false;
                }
            default: return true;
        }
    }
}
