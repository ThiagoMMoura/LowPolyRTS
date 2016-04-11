using UnityEngine;
using System.Collections;

[System.Serializable]
public class Deposito : IDeposito
{
    public GameObject gameObject;
    public TipoRecurso tipo;
    public int capacidadeMaxima;
    public int quantidadeAtual;

    public int CapacidadeDisponivel
    {
        get{ return capacidadeMaxima - quantidadeAtual; }
    }

    public bool DepositoLimitado
    {
        get
        {
            return capacidadeMaxima > 0;
        }
    }

    public int QuantidadeAtual
    {
        get
        {
            return quantidadeAtual;
        }
    }

    public TipoRecurso Tipo
    {
        get
        {
            return tipo;
        }
    }

    public bool EstaCheio
    {
        get
        {
            return capacidadeMaxima == quantidadeAtual;
        }
    }

    public Transform transform
    {
        get
        {
            return gameObject.transform;
        }
    }

    public int DepositarRecurso(int quantidade)
    {
        int disponivel = CapacidadeDisponivel;
        if(quantidade <= disponivel)
        {
            quantidadeAtual += quantidade;
            return quantidade;
        }
        quantidadeAtual += disponivel;
        return disponivel;
    }

    public int UsarRecurso(int quantidade)
    {
        if(quantidadeAtual >= quantidade)
        {
            quantidadeAtual -= quantidade;
            return quantidade;
        }
        int retorna = quantidadeAtual;
        quantidadeAtual = 0;
        return retorna;
    }

    public bool isTipoAceito(TipoRecurso tipo)
    {
        return this.tipo == tipo;
    }
}
