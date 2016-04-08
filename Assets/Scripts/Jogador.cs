using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jogador : MonoBehaviour{
    public int id;
    public string nome;
    public List<Unidade> unidades;

    void Start()
    {
        ControlePartida.AddJogador(this);
    }

    public void AddUnidade(Unidade unidade)
    {
        unidade.IdJogador = id;
        unidades.Add(unidade);
    }

    public IDeposito ObterDepositoRecursoMaisProximo(TipoRecurso tipo, Vector3 relativeTo)
    {
        float minDistance = Mathf.Infinity;
        Estatica deposito = null;

        foreach (Unidade unit in unidades)
        {
            if (unit is Estatica && (unit as Estatica).IsDepositoTipoRecurso(tipo))
            {
                float currentDistance = Vector3.Distance(unit.transform.position, relativeTo);
                if (currentDistance < minDistance)
                {
                    deposito = unit as Estatica;
                    minDistance = currentDistance;
                }
            }
        }
        if (deposito != null)
        {
            return deposito.ObterDepositoPorTipo(tipo);
        }
        return null;
    }
}
