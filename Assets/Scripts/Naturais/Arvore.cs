using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FonteRecurso))]
public class Arvore : Natural,IRecurso {
    public PArvore _propriedadesArvore;

    public int quantidade
    {
        get
        {
            return _propriedadesArvore.quantidade;
        }
    }

    public TipoRecurso tipo
    {
        get
        {
            return _propriedadesArvore.tipo;
        }
    }

    // Use this for initialization
    internal override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	internal override void Update () {
        base.Update();
	}
}
