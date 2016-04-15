using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jogador : MonoBehaviour{
    public int id;
    public string nome;
    public List<Unidade> unidades;
    public CentroDepositosRecursos centroRecursos;

    void Awake()
    {
        centroRecursos = new CentroDepositosRecursos();
    }

    void Start()
    {
        ControlePartida.AddJogador(this);
    }

    public void AddUnidade(Unidade unidade)
    {
        unidade.idJogador = id;
        unidades.Add(unidade);

        Deposito d = unidade.GetComponent<Deposito>();
        if(d!=null)
        {
            centroRecursos.AddDeposito(d);
        }
    }

    public Deposito ObterDepositoRecursoMaisProximo(TipoRecurso tipo, Vector3 relativeTo, bool incluiCheio = false)
    {
        float minDistance = Mathf.Infinity;
        Deposito deposito = null;

        foreach (Deposito unit in centroRecursos.ObterDeposito(tipo))
        {
            float currentDistance = Vector3.Distance(unit.transform.position, relativeTo);
            if (currentDistance < minDistance && (incluiCheio || !unit.EstaCheio))
            {
                deposito = unit;
                minDistance = currentDistance;
            }
        }
        return deposito;
    }
}
