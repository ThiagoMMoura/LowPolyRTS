using UnityEngine;
using System.Collections;

public class TitularDadosEntidades {

    public PCivil[] dadosCivis;
    public PUnidade[] dadosConstrucoes;

    private string _caminhoXmlCivil = "XML Files/DadosCivis";

    public TitularDadosEntidades()
    {
        Debug.Log("Titular entidades");
        TextAsset nome = Resources.Load<TextAsset>(_caminhoXmlCivil);
        dadosCivis = XMLParser.ParseCivil(nome.text);
    }

    public PEntidade ObterEntidadePorId(int id)
    {
        foreach (PCivil m in dadosCivis)
        {
            Debug.Log("Id: " + m.id);
            if (m.id == id)
            {
                return m;
            }
        }

        //foreach (StaticEntityProperties s in _staticProps)
        //{
        //    if (s.Id == id)
        //    {
        //        return s;
        //    }
        //}

        return null;
    }
}
