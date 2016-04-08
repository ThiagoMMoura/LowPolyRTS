using UnityEngine;
using System.Collections;
using System;

public enum TipoRecurso
{
    Alimento,
    Madeira,
    Pedra,
    Ouro,
    Metal,
}
[System.Serializable]
public class FonteRecurso: MonoBehaviour, IRecurso{

    public TipoRecurso tipo;
    public int quantidadeAtual;

    public bool EstaVazio
    {
        get
        {
            return quantidadeAtual == 0;
        }
    }

    public TipoRecurso Tipo
    {
        get
        {
            return tipo;
        }
    }

    public bool IsTipo(TipoRecurso tipo)
    {
        return this.tipo == tipo;
    }

    public int Colher(int quantidade)
    {
        if (quantidadeAtual >= quantidade)
        {
            quantidadeAtual -= quantidade;
            return quantidade;
        }
        int retorna = quantidadeAtual;
        quantidadeAtual = 0;
        return retorna;
    }
}
