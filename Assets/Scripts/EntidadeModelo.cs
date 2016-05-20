using UnityEngine;
using System.Collections;
using System;

public class EntidadeModelo : MonoBehaviour, IEntidade
{
    public PEntidade _propriedades;
    public int largura;
    public int altura;

    public Atividades atividade
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
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
}
