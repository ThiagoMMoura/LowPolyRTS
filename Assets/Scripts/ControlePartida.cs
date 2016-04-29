using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InterfaceUsuario.PainelRecursos;

public class ControlePartida : MonoBehaviour {
    public static int jogadorHumano = 1;
    public static Mundo mundo;
    private Jogador humano;
    private static List<Jogador> jogadores;
	
	void Awake () {
        print("Controle Partida: passo 1");
        jogadores = new List<Jogador>(FindObjectsOfType<Jogador>());
        foreach(Jogador j in jogadores)
        {
            j.transform.SetParent(transform);
            if (j.id == jogadorHumano)
            {
                humano = j;
            }
        }
        mundo = FindObjectOfType<Mundo>();
	}
	
	// Update is called once per frame
	void Update () {
        List<Deposito> madeira = humano.centroRecursos.ObterDepositoMadeira();
        if (madeira.Count > 0)
        {
            int soma = 0;
            foreach (Deposito m in madeira)
            {
                soma += m.quantidadeAtual;
            }
            Madeira.quantidade = soma;
        }
        List<Deposito> pedra = humano.centroRecursos.ObterDepositoPedra();
        if (pedra.Count > 0)
        {
            int soma = 0;
            foreach (Deposito p in pedra)
            {
                soma += p.quantidadeAtual;
            }
            Pedra.quantidade = soma;
        }
    }

    public static void AddJogador(Jogador jogador)
    {
       jogadores.Add(jogador);
    }

    public static Jogador ObterJogador(int id)
    {
        if (jogadores != null)
        {
            foreach (Jogador j in jogadores)
            {
                if (j.id == id)
                {
                    return j;
                }
            }
        }
        return null;
    }
}
