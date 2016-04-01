using UnityEngine;
using System.Collections;

public enum Sexo
{
    Macho,
    Femea,
}
public class Humano : Movel {

    public Sexo sexo;
    public int idade;
    public int expectativaDeVida;
    // Use this for initialization
    internal override void Start () {
        base.Start();
        StartCoroutine(Envelhecer());
    }

    // Update is called once per frame
    internal override void Update () {
        base.Update();
	}

    private IEnumerator Envelhecer()
    {
        while (idade <= expectativaDeVida) {
            yield return new WaitForSeconds(Tempo.ANO);
            idade++;
            this.AoEnvelhecer();
        }
        Destroy(unidade);
    }

    public virtual void AoEnvelhecer() {}
}
