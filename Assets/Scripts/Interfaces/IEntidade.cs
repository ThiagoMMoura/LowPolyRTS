using UnityEngine;
using System.Collections;

public interface IEntidade{

    int id { get;}
    string nome { get; }
    string descricao { get; }
    PEntidade propriedades { get; set; }

    Atividades atividade { get; set; }
    bool EstaDisponivel();
}
