using UnityEngine;
using System.Collections;

public class Unidade : MonoBehaviour {

    public GameObject unidade;
    public int id;
    public int vitalidade;
    [Range(0f,100f)]public float resistencia;
    private bool isSelecionado;

	// Use this for initialization
	internal virtual void Start () {
	
	}

    // Update is called once per frame
    internal virtual void Update () {
	
	}
}
