using UnityEngine;
using System.Collections;

public interface IColetor:IUnidade{

    int recursosColetadosPorSegundo { get; }
    int maxRecursosPorCarregamento { get; }
    TipoRecurso[] tiposColetaveis { get; }
}
