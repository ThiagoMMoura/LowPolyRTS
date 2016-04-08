using UnityEngine;
using System.Collections;

public class Unidade : MonoBehaviour {

    public GameObject objUnidade;
    public int id;
    public int vitalidade;
    public int idJogador;
    [Range(0f,100f)]public float resistencia;
    private bool isSelecionado;

	// Use this for initialization
	internal virtual void Start () {
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

    // Update is called once per frame
    internal virtual void Update () {
	
	}

    public int IdJogador
    {
        get { return idJogador; }
        set { idJogador = value; }
    }

}
