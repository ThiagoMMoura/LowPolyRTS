using UnityEngine;
using System.Collections;

public interface IDeposito {

    TipoRecurso tipo { get; }
    int capacidadeMaxima { get; }
    int maxTrabalhadores { get; }
}
