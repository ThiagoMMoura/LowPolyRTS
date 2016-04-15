using UnityEngine;
using System.Collections;

public interface ICivil:Humano,IColetor {

    new PCivil propriedades { get; set; }
}
