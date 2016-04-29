using UnityEngine;
using System.Collections;

public interface IUnidade: IEntidade{

	int vitalidade { get; }
    int idJogador { get; set; }
    new PUnidade propriedades { get; set; }

    void Danificar(int dano);
}
