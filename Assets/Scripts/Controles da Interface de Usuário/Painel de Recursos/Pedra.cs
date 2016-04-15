using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace InterfaceUsuario.PainelRecursos
{
    public class Pedra : MonoBehaviour
    {
        public static int quantidade;

        Text texto;

        void Awake()
        {
            texto = GetComponent<Text>();
            quantidade = 0;
        }

        // Update is called once per frame
        void Update()
        {
            texto.text = quantidade.ToString();
        }
    }
}