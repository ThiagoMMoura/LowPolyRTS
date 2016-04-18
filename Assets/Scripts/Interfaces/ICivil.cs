using UnityEngine;
using System.Collections;

public interface ICivil: IHumano,IColetor {

    new PCivil propriedades { get; set; }
}
