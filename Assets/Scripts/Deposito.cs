using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Unidade))]
public class Deposito : MonoBehaviour
{
    public TipoRecurso tipo;
    public int capacidadeMaxima;
    public int quantidadeAtual;
    public int maxTrabalhadores;
    public List<Civil> trabalhadores;

    public void Start()
    {
        IDeposito deposito = GetComponent<IDeposito>();
        if(deposito != null)
        {
            tipo = deposito.tipo;
            capacidadeMaxima = deposito.capacidadeMaxima;
            maxTrabalhadores = deposito.maxTrabalhadores;
        }
    }

    public void Update()
    {
        foreach(Civil c in trabalhadores)
        {
            if (c != null && c.EstaDisponivel())
            {
                if(c.atividade != Atividades.colhendo && c.atividade != Atividades.carregando)
                {
                    FonteRecurso f = ControlePartida.mundo.ObterFonteRecursoMaisProximo(tipo,transform);
                    if (f != null)
                    {
                        print(c.nome);
                        StartCoroutine(c.ObterColetor().IniciarColetaRecursoParaDeposito(f,this));
                    }
                }
            }
        }
    }

    public int CapacidadeDisponivel
    {
        get{ return capacidadeMaxima - quantidadeAtual; }
    }

    public bool EstaCheio
    {
        get
        {
            return capacidadeMaxima <= quantidadeAtual;
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
