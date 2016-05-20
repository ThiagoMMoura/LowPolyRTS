using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AssentadorConstrucao : MonoBehaviour {
    public List<EntidadeModelo> entidadesModelo;
    public int quadra;
    private static int _quadra;
    public CanvasGroup menu;
    
    private static GameObject _canteiro;
    private int _layerCliked;
    private float _contTime;

    void Start()
    {
        if(quadra <= 0)
        {
            quadra = 2;
        }
        _layerCliked = 0;
        _contTime = 0f;
        _quadra = quadra;
    }

    public static bool EstaAssentando
    {
        get { return _canteiro != null; }
    }

    public void Criar(int id)
    {
        Cancelar();
        foreach(EntidadeModelo m in entidadesModelo)
        {
            if(m.id == id)
            {
                IniciarAssentamento(Instantiate(m.gameObject));
                break;
            }
        }
    }

    public static void IniciarAssentamento(GameObject construcao)
    {
        _canteiro = construcao;
        if (EstaAssentando)
        {
            Ray r = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2,0));

            foreach (RaycastHit hit in Physics.RaycastAll(r))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Terra"))
                {
                    int x = (int)(hit.point.x - (hit.point.x % _quadra));
                    int z = (int)(hit.point.z - (hit.point.z % _quadra));
                    _canteiro.transform.position = new Vector3(x, hit.point.y+1, z);
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (EstaAssentando)
        {
            menu.interactable = true;
            menu.blocksRaycasts = true;
            menu.alpha = 1;
            
            if (Input.GetButtonDown("Fire1"))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(r,out hit))
                {
                    _layerCliked = hit.transform.gameObject.layer;
                }
            }

            if (Input.GetButton("Fire1"))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

                foreach(RaycastHit hit in Physics.RaycastAll(r))
                {
                    if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Terra") && _layerCliked == LayerMask.NameToLayer("Assentador"))
                    {
                        int x = (int)(hit.point.x);
                        int z = (int)(hit.point.z);
                        if (x % quadra != 0)
                        {
                            x = (int)_canteiro.transform.position.x;
                        }
                        if (z % quadra != 0)
                        {
                            z = (int)_canteiro.transform.position.z;
                        }
                        //if (x % quadra == 0 || z % quadra == 0)
                        //{
                        Vector3 point = RayscastLayer(new Ray(new Vector3(x, 500, z), Vector3.down),8).point;//new Vector3(x, y, z);
                        point.Set(point.x, point.y + 1, point.z);
                        _canteiro.transform.position = point;
                        //}
                        break;
                    }
                }
                _contTime += Time.deltaTime;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                if(_contTime < 0.1f)
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = RayscastLayer(r, 8);

                    int x = (int)(hit.point.x - (hit.point.x % _quadra));
                    int z = (int)(hit.point.z - (hit.point.z % _quadra));
                    _canteiro.transform.position = new Vector3(x, hit.point.y + 1, z);
                }
                _contTime = 0f;
            }
            Vector3 raio = _canteiro.GetComponentInChildren<BoxCollider>().transform.localScale;
            menu.transform.position = Camera.main.WorldToScreenPoint(new Vector3(_canteiro.transform.position.x /*+ (raio.x/2)*/, _canteiro.transform.position.y - (raio.y/2), _canteiro.transform.position.z - (raio.z/2)));
        }
        else
        {
            menu.interactable = false;
            menu.blocksRaycasts = false;
            menu.alpha = 0;
        }
    }

    public static RaycastHit RayscastLayer(Ray r, int layer)
    {
        foreach (RaycastHit hit in Physics.RaycastAll(r))
        {
            if (hit.transform.gameObject.layer == layer)
            {
                return hit;
            }
        }
        return new RaycastHit();
    }

    public static void Cancelar()
    {
        Destroy(_canteiro);
        _canteiro = null;
    }
    
    public void Assentar(bool confirma)
    {
        if (confirma)
        {

        }
        else
        {
            Cancelar();
        }
    }

    public void Rotacionar(bool direita)
    {
        if (direita)
        {
            _canteiro.transform.Rotate(new Vector3(0, -45, 0));
        }
        else
        {
            _canteiro.transform.Rotate(new Vector3(0, 45, 0));
        }
    }
}
