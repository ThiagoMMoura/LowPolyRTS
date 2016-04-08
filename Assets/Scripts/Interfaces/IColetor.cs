using UnityEngine;
using System.Collections;

public interface IColetor{

	Deposito[] depositos
    {
        get;
    }

    int UnidadesColetadasPorSegundo
    {
        get;
    }
    bool TipoAceito(TipoRecurso tipo);
    
    bool EstaCheio(TipoRecurso tipo);
    int DepositarRecurso(int quantidade, TipoRecurso tipo);
    int ColherRecurso(IRecurso fonte);
    IEnumerator IniciarColetaRecurso(IRecurso fonte);
}
