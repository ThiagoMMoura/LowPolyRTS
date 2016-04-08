using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlePartida : MonoBehaviour {
    public int jogadorHumano;
    private static List<Jogador> jogadores;
	// Use this for initialization
	void Awake () {
        jogadorHumano = 0;
        jogadores = new List<Jogador>(FindObjectsOfType<Jogador>());
        foreach(Jogador j in jogadores)
        {
            j.transform.SetParent(transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
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
