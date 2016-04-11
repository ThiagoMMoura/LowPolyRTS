using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
    private float _maxZoom;
    private float _minZoom;
    private Vector2 _posicaoAtual;
    private Vector2 _posicaoAnterior;
	// Use this for initialization
	void Start () {
        _maxZoom = 200;
        _minZoom = 50;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            _posicaoAtual = Vector2.zero;
            _posicaoAnterior = Vector2.zero;
        }
        if (Input.GetButton("Fire1"))
        {
            _posicaoAnterior = _posicaoAtual;
            _posicaoAtual = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            //float distancia = Vector2.Distance(_posicaoAnterior, _posicaoAtual);
            if (_posicaoAnterior != Vector2.zero)
            {
                Vector3 posicao = new Vector3((_posicaoAnterior.x - _posicaoAtual.x)*0.1f, 0,( _posicaoAnterior.y - _posicaoAtual.y)*0.1f);
                print(posicao.ToString());
                transform.position = transform.position + posicao;
            }
        }
	}
}
