using UnityEngine;
using System.Collections;

public class Mortal : MonoBehaviour {

    public int idade;
    public int expectativaDeVida;
    public IMortal[] aoEnvelhecer;
    // Use this for initialization
    void Start () {
        IMortal mortal = GetComponent<IMortal>();
        if(mortal != null)
        {
            expectativaDeVida = mortal.expectativaDeVida;
        }
        StartCoroutine(Envelhecer());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator Envelhecer()
    {
        while (idade < expectativaDeVida)
        {
            yield return new WaitForSeconds(Tempo.ANO);
            idade++;
            if(aoEnvelhecer != null)
            {
                foreach(IMortal m in aoEnvelhecer)
                {
                    m.AoEnvelhecer();
                }
            }
        }
        Destroy(gameObject);
    }

}
