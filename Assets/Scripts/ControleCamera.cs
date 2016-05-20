using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
    //public float velocidade;
    private float _maxZoom;
    private float _minZoom;
    private Vector2 _posicaoAtual;
    private Vector2 _posicaoAnterior;
    private int _layer;
    // Use this for initialization
    void Start () {
        _maxZoom = 40;
        _minZoom = 5;
        _layer = 0;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonUp("Fire1"))
        {
            _posicaoAtual = Vector2.zero;
            _posicaoAnterior = Vector2.zero;
            _layer = 0;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                _layer = hit.transform.gameObject.layer;
            }
        }

        if (Input.GetButton("Fire1"))
        {
            if(_layer != LayerMask.NameToLayer("Assentador")) {
                _posicaoAnterior = _posicaoAtual;
                _posicaoAtual = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                if (_posicaoAnterior != Vector2.zero)
                {
                    Vector3 posicao = new Vector3((_posicaoAnterior.x - _posicaoAtual.x) * Time.deltaTime, 0, (_posicaoAnterior.y - _posicaoAtual.y) * Time.deltaTime);
                    transform.position = transform.position + posicao;
                }
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
