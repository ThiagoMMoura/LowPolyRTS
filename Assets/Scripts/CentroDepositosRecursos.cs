using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CentroDepositosRecursos {
    private List<Deposito> madeira;
    private List<Deposito> pedra;

    public CentroDepositosRecursos()
    {
        madeira = new List<Deposito>();
        pedra = new List<Deposito>();
    }

    public bool AddDepositoMadeira(Deposito dep)
    {
        if(dep.tipo == TipoRecurso.Madeira)
        {
            madeira.Add(dep);
            return true;
        }
        return false;
    }

    public bool AddDepositoPedra(Deposito dep)
    {
        if (dep.tipo == TipoRecurso.Pedra)
        {
            madeira.Add(dep);
            return true;
        }
        return false;
    }

    public void AddDeposito(Deposito dep)
    {
        switch (dep.tipo)
        {
            case TipoRecurso.Pedra:
                {
                    pedra.Add(dep);
                    break;
                }
            case TipoRecurso.Madeira:
                {
                    madeira.Add(dep);
                    break;
                }
        }
        Debug.Log(dep.tipo.ToString());
    }

    public List<Deposito> ObterDeposito(TipoRecurso tipo)
    {
        switch (tipo)
        {
            case TipoRecurso.Pedra:
                {
                    return pedra;
                }
            case TipoRecurso.Madeira:
                {
                    return madeira;
                }
            default: return new List<Deposito>();
        }
    }

    public List<Deposito> ObterDepositoMadeira()
    {
        return ObterDeposito(TipoRecurso.Madeira);
    }

    public List<Deposito> ObterDepositoPedra()
    {
        return ObterDeposito(TipoRecurso.Pedra);
    }
}
