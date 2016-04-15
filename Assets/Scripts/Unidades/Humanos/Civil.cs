using UnityEngine;
using System.Collections;
using System;

public class Civil : ICivil
{
    public bool isTrabalhador;

    public PCivil propriedadesCivil;

    public PCivil propriedades
    {
        get { return propriedadesCivil; }
        set { propriedadesCivil = value; }
    }

    public PHumano IHumano.propriedades
    {
        get { return propriedadesCivil; }
        set { propriedadesCivil = value as PCivil; }
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
            throw new NotImplementedException();
        }
    }

    public TipoRecurso[] tiposColetaveis
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    // Use this for initialization
    internal override void Start () {
        base.Start();
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
}
