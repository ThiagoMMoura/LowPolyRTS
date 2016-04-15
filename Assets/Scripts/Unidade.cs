using UnityEngine;
using System.Collections;

public class Unidade : MonoBehaviour {

    public int idJogador;

	// Use this for initialization
	internal virtual void Start () {
        IUnidade uni = GetComponent<IUnidade>();
        if(uni != null)
        {
            idJogador = uni.idJogador;
        }
        Jogador j = GetComponentInParent<Jogador>();
        if (!j)//Se jogador não for null
        {
            j = GameObject.Find("Jogador" + idJogador).GetComponent<Jogador>();
            transform.SetParent(j.transform);
            if (j) { j.AddUnidade(this); }
            else { Destroy(gameObject); }
        }
        else
        {
            j.AddUnidade(this);
        }
    }

}
