using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Jogador))]
public class ControleJogadorHumano : MonoBehaviour {

    public int idJogador;
	// Use this for initialization
	void Start () {
        idJogador = ControlePartida.jogadorHumano;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit; //Pontos da colisão...
        //    if (Physics.Raycast(ray.origin, ray.direction, out hit))
        //    {
        //        FonteRecurso fonte = hit.transform.GetComponent<FonteRecurso>();
        //        if(fonte != null)
        //        {

        //        }
        //    }
        //}
    }
}
