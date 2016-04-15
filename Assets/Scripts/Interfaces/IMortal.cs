using UnityEngine;
using System.Collections;

public interface IMortal {

    int expectativaDeVida { get; }

    void AoEnvelhecer();
}
