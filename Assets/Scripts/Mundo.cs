using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mundo : MonoBehaviour {
    public List<Natural> _natural;
    public CentroFonteRecursos centroFonteRecursos;
	
	void Awake () {
        centroFonteRecursos = new CentroFonteRecursos();
        _natural = new List<Natural>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddNatural(Natural natu)
    {
        _natural.Add(natu);

        FonteRecurso f = natu.GetComponent<FonteRecurso>();
        if (f != null)
        {
            centroFonteRecursos.AddFonteRecurso(f);
        }
    }

    public bool RemoveNatural(Natural natu)
    {
        if (_natural.Remove(natu))
        {
            FonteRecurso f = natu.GetComponent<FonteRecurso>();
            if (f != null)
            {
                return centroFonteRecursos.RemoveFonteRecurso(f);
            }
            return true;
        }
        return false;
    }

    public FonteRecurso ObterFonteRecursoMaisProximo(TipoRecurso tipo, Transform target)
    {
        float minDistance = Mathf.Infinity;
        FonteRecurso fonte = null;

        foreach (FonteRecurso f in centroFonteRecursos.ObterFonteRecurso(tipo))
        {
            float distanciaAtual = Vector3.Distance(f.transform.position, target.position);
            
            if (distanciaAtual < minDistance)
            {
                fonte = f;
                minDistance = distanciaAtual;
            }
        }
        return fonte;
    }
}
