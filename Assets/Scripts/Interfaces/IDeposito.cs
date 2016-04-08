using UnityEngine;
using System.Collections;

public interface IDeposito {

    TipoRecurso Tipo
    {
        get;
    }

    bool DepositoLimitado
    {
        get;
    }

    int CapacidadeDisponivel
    {
        get;
    }

    int QuantidadeAtual
    {
        get;
    }

    bool EstaCheio
    {
        get;
    }

    Transform transform
    {
        get;
    }
    bool isTipoAceito(TipoRecurso tipo);
    int DepositarRecurso(int quantidade);
    int UsarRecurso(int quantidade);
}
