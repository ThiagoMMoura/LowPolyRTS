using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Unidade))]
[RequireComponent(typeof(Mortal))]
[RequireComponent(typeof(Movel))]
[RequireComponent(typeof(Coletor))]
public class Humano : MonoBehaviour,IMortal,IHumano,IMovel {

    private Sexo _sexo;
    private Mortal _mortal;

    public PHumano propriedadesHumano;
    public bool isReprodutor;

    public Sexo sexo
    {
        get
        {
            return propriedadesHumano.sexo;
        }
    }

    public Mortal mortal
    {
        get { return _mortal; }
    }

    public PHumano propriedades
    {
        get
        {
            return propriedadesHumano;
        }

        set
        {
            propriedadesHumano = value;
        }
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

    internal virtual void Start () {
        _mortal = GetComponent<Mortal>();
    }

    // Update is called once per frame
    internal virtual void Update () {
        
	}

    public virtual void AoEnvelhecer() {}

    public virtual void Danificar(int dano) {}

}
