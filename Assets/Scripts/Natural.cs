using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Atividade))]
public class Natural : MonoBehaviour, IEntidade {
    private PEntidade _propriedades;
    private Atividade _atividade;

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

    public string descricao
    {
        get
        {
            return _propriedades.descricao;
        }
    }

    public int id
    {
        get
        {
            return _propriedades.id;
        }
    }

    public string nome
    {
        get
        {
            return _propriedades.nome;
        }
    }

    public PEntidade propriedades
    {
        get
        {
            return _propriedades;
        }

        set
        {
            _propriedades = value;
        }
    }

    public bool EstaDisponivel()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    internal virtual void Start () {
        Mundo m = FindObjectOfType<Mundo>();
        if(m != null)
        {
            m.AddNatural(this);
        }
        else
        {
            Destroy(gameObject);
        }
        _atividade = GetComponent<Atividade>();
	}

    // Update is called once per frame
    internal virtual void Update () {
	
	}
}
