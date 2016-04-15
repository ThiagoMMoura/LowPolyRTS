using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movel))]
public class Coletor : MonoBehaviour {

    public int recursosColetadosPorSegundo;
    public int maxRecursosPorCarregamento;
    public TipoRecurso[] tiposColetaveis;
    public int idJogador;
    private int quantidadeRecursoAtual;
    private TipoRecurso recursoAtual;
    private Movel _movel;
    
    void Start () {
        IColetor coletor = GetComponent<IColetor>();
        if (coletor != null)
        {
            recursosColetadosPorSegundo = coletor.recursosColetadosPorSegundo;
            maxRecursosPorCarregamento = coletor.maxRecursosPorCarregamento;
            tiposColetaveis = coletor.tiposColetaveis;
            idJogador = coletor.idJogador;
        }
        _movel = GetComponent<Movel>();
	}
	
	
	void Update () {
	
	}

    public bool IsColetorDe(TipoRecurso tipo)
    {
        foreach(TipoRecurso t in tiposColetaveis)
        {
            if (t == tipo)
            {
                return true;
            }
        }
        return false;
    }

    public bool EstaCheio()
    {
        return quantidadeRecursoAtual >= maxRecursosPorCarregamento;
    }

    public int CapacidadeDisponivel
    {
        get { return maxRecursosPorCarregamento - quantidadeRecursoAtual; }
    }

    public bool ColherRecurso(FonteRecurso fonte)
    {
        if (!fonte.EstaVazio)
        {
            if (CapacidadeDisponivel > recursosColetadosPorSegundo)
            {
                quantidadeRecursoAtual += fonte.Colher(recursosColetadosPorSegundo);
            }
            else
            {
                quantidadeRecursoAtual += fonte.Colher(CapacidadeDisponivel);
            }
            return true;
        }
        return false;
    }

    public IEnumerator IniciarColetaRecurso(FonteRecurso fonte)
    {
        if (IsColetorDe(fonte.tipo))
        {
            while (!fonte.EstaVazio)
            {
                if (quantidadeRecursoAtual == 0 || recursoAtual == fonte.tipo)
                {
                    yield return StartCoroutine(_movel.MoverQualquerCustoPara(fonte.transform));
                    while (!EstaCheio())
                    {
                        yield return new WaitForSeconds(1);
                        if (!ColherRecurso(fonte)) { break; }
                    }
                    recursoAtual = fonte.tipo;
                }
                Deposito depositoProximo = ControlePartida.ObterJogador(idJogador).ObterDepositoRecursoMaisProximo(recursoAtual, transform.position);
                if (depositoProximo == null)
                {
                    print("Parando IniciarColetaRecurso");
                    StopAllCoroutines();
                }
                yield return StartCoroutine(_movel.MoverQualquerCustoPara(depositoProximo.transform));
                quantidadeRecursoAtual -= depositoProximo.DepositarRecurso(quantidadeRecursoAtual);
            }
        }
    }
}
