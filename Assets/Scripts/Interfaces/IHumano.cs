using UnityEngine;
using System.Collections;

public enum Sexo
{
    Macho,
    Femea,
}
public interface IHumano: IUnidade {

	Sexo sexo { get; }
    new PHumano propriedades { get; set; }
}
