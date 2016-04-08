using UnityEngine;
using System.Collections;

public interface IRecurso{

    bool EstaVazio
    {
        get;
    }

    TipoRecurso Tipo
    {
        get;
    }

    Transform transform
    {
        get;
    }

    bool IsTipo(TipoRecurso tipo);
    int Colher(int quantidade);
}
