using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Recurso
{
    public TipoRecurso tipo;
    public int quantidade;

    public Recurso(TipoRecurso tipo,int quantidade)
    {
        this.tipo = tipo;
        this.quantidade = quantidade;
    }
}
public class RecursosNecessarios {

    public List<Recurso> recursos;

    public RecursosNecessarios(List<Recurso> rec)
    {
        recursos = rec;
    }

    public RecursosNecessarios()
    {
        recursos = new List<Recurso>();
    }

    public void Add(Recurso recurso)
    {
        recursos.Add(recurso);
    }

    public bool Remove(Recurso recurso)
    {
        return recursos.Remove(recurso);
    }
}
