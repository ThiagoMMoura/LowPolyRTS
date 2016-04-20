using UnityEngine;
using System.Collections;

public enum Atividades
{
    colhendo,
    plantando,
    carregando,
    marchando,
    dormindo,
    correndo,
    morrendo,
    crescendo,
    caminhando,
    esperando,
}
public class Atividade : MonoBehaviour {

    public Atividades atividade;
	
	void Start () {
        atividade = Atividades.esperando;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
