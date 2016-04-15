using UnityEngine;
using System.Collections;

public class Estatica : MonoBehaviour {
    public Deposito[] depositos;

    public bool IsDepositoRecurso
    {
        get { return depositos.Length > 0; }
    }

    
    internal virtual void Start () {
        
    }

    internal virtual void Update () {
    }

    public bool IsDepositoTipoRecurso(TipoRecurso tipo)
    {
        return ObterDepositoPorTipo(tipo) != null;
    }

    public Deposito ObterDepositoPorTipo(TipoRecurso tipo)
    {
        for (int i = 0; i < depositos.Length; i++)
        {
            if (depositos[i].isTipoAceito(tipo))
            {
                return depositos[i];
            }
        }
        return null;
    }

    public bool EstaCheio(TipoRecurso tipo)
    {
        Deposito d = ObterDepositoPorTipo(tipo);
        if (d != null)
        {
            return d.EstaCheio;
        }
        return true;
    }
}
