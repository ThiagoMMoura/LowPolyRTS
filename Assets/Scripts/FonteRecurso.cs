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
public class FonteRecurso: MonoBehaviour{

    public TipoRecurso tipo;
    public int quantidade;

    void Start()
    {
        IRecurso recurso = GetComponent<IRecurso>();
        if (recurso != null)
        {
            tipo = recurso.tipo;
            quantidade = recurso.quantidade;
        }
    }

    public bool EstaVazio
    {
        get
        {
            return quantidade == 0;
        }
    }

    public bool isTipo(TipoRecurso tipo)
    {
        return this.tipo == tipo;
    }

    public int Colher(int qtd)
    {
        if (quantidade >= qtd)
        {
            quantidade -= qtd;
            return quantidade;
        }
        int retorna = quantidade;
        quantidade = 0;
        return retorna;
    }
}
