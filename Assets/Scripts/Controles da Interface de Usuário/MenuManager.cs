using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Menu menuAtual;

    public void Start()
    {
        //ExibirMenu(menuAtual);
    }

    public void ExibirMenu(Menu menu)
    {
        if(menuAtual != null)
        {
            menuAtual.EstaAberto = false;
        }

        menuAtual = menu;
        menuAtual.EstaAberto = true;
    }
}
