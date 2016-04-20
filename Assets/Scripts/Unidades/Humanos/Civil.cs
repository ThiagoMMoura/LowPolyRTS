using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Coletor))]
public class Civil : Humano, ICivil
{
    public bool isTrabalhador;
    public PCivil propriedadesCivil;
    private Coletor _coletor;

    PCivil ICivil.propriedades
    {
        get { return propriedadesCivil; }
        set { propriedadesCivil = value; }
    }

    public int recursosColetadosPorSegundo
    {
        get
        {
            return propriedadesCivil.recursosColetadosPorSegundo;
        }
    }

    public int maxRecursosPorCarregamento
    {
        get
        {
            return propriedadesCivil.maxRecursosPorCarregamento;
        }
    }

    public TipoRecurso[] tiposColetaveis
    {
        get
        {
            return propriedadesCivil.tiposColetaveis;
        }
    }

    // Use this for initialization
    internal override void Start () {
        base.Start();
        _coletor = GetComponent<Coletor>();
	}

    // Update is called once per frame
    internal override void Update () {
        base.Update();
    }

    public override void AoEnvelhecer()
    {
        if (mortal.idade >= 16)
        {
            if (mortal.idade >= 20)
            {
                isReprodutor = true;
                isTrabalhador = true;
            }
        }
    }

    public Coletor ObterColetor()
    {
        return _coletor;
    }
}
