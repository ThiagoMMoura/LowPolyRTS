using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CentroFonteRecursos {
    private List<FonteRecurso> _madeira;
    private List<FonteRecurso> _pedra;
    private List<FonteRecurso> _ouro;

    public CentroFonteRecursos()
    {
        _madeira = new List<FonteRecurso>();
        _pedra = new List<FonteRecurso>();
        _ouro = new List<FonteRecurso>();
    }

    public void AddFonteRecurso(FonteRecurso fonte)
    {
        switch (fonte.tipo)
        {
            case TipoRecurso.Pedra:
                {
                    _pedra.Add(fonte);
                    break;
                }
            case TipoRecurso.Madeira:
                {
                    _madeira.Add(fonte);
                    break;
                }
            case TipoRecurso.Ouro:
                {
                    _ouro.Add(fonte);
                    break;
                }
        }
    }

    public bool RemoveFonteRecurso(FonteRecurso fonte)
    {
        switch (fonte.tipo)
        {
            case TipoRecurso.Pedra:
                {
                    return _pedra.Remove(fonte);
                }
            case TipoRecurso.Madeira:
                {
                    return _madeira.Remove(fonte);
                }
            case TipoRecurso.Ouro:
                {
                    return _ouro.Remove(fonte);
                }
        }
        return false;
    }

    public bool AddFonteRecursoMadeira(FonteRecurso fonte)
    {
        if (fonte.tipo == TipoRecurso.Madeira)
        {
            _madeira.Add(fonte);
            return true;
        }
        return false;
    }

    public bool AddFonteRecursoPedra(FonteRecurso fonte)
    {
        if (fonte.tipo == TipoRecurso.Pedra)
        {
            _madeira.Add(fonte);
            return true;
        }
        return false;
    }

    public bool AddFonteRecursoOuro(FonteRecurso fonte)
    {
        if (fonte.tipo == TipoRecurso.Ouro)
        {
            _madeira.Add(fonte);
            return true;
        }
        return false;
    }

    public List<FonteRecurso> ObterFonteRecurso(TipoRecurso tipo)
    {
        switch (tipo)
        {
            case TipoRecurso.Pedra:
                {
                    return _pedra;
                }
            case TipoRecurso.Madeira:
                {
                    return _madeira;
                }
            case TipoRecurso.Ouro:
                {
                    return _ouro;
                }
            default: return new List<FonteRecurso>();
        }
    }

    public List<FonteRecurso> ObterFonteRecursoMadeira()
    {
        return ObterFonteRecurso(TipoRecurso.Madeira);
    }

    public List<FonteRecurso> ObterFonteRecursoPedra()
    {
        return ObterFonteRecurso(TipoRecurso.Pedra);
    }

    public List<FonteRecurso> ObterFonteRecursoOuro()
    {
        return ObterFonteRecurso(TipoRecurso.Ouro);
    }
}
