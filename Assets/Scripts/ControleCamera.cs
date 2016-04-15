using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
    private float _maxZoom;
    private float _minZoom;
    private Vector2 _posicaoAtual;
    private Vector2 _posicaoAnterior;
	// Use this for initialization
	void Start () {
        _maxZoom = 20;
        _minZoom = 5;
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
            if (_posicaoAnterior != Vector2.zero)
            {
                Vector3 posicao = new Vector3((_posicaoAnterior.x - _posicaoAtual.x)*0.1f, 0,( _posicaoAnterior.y - _posicaoAtual.y)*0.1f);
                transform.position = transform.position + posicao;
            }
        }
        
        if (Input.mouseScrollDelta.y != 0)
        {
            float y = Input.mouseScrollDelta.y;
            if (y < 0)
            {
                if(transform.position.y - _minZoom >= -y)
                {
                    transform.position = transform.position + new Vector3(0, y, -y);
                }
            }
            else
            {
                if (_maxZoom - transform.position.y >= y)
                {
                    transform.position = transform.position + new Vector3(0, y, -y);
                }
            }
        }
        if (Input.GetButton("Fire3"))
        {

        }
	}
}
