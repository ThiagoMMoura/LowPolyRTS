using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movel))]
[RequireComponent(typeof(Atividade))]
public class Coletor : MonoBehaviour {

    public int recursosColetadosPorSegundo;
    public int maxRecursosPorCarregamento;
    public TipoRecurso[] tiposColetaveis;
    public int idJogador;
    private int quantidadeRecursoAtual;
    private TipoRecurso recursoAtual;
    private Movel _movel;
    private Atividade _atividade;
    
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
        _atividade = GetComponent<Atividade>();
	}
	
	
	void Update () {
	
	}

    public bool IsColetorDe(TipoRecurso tipo)
    {
        if (tiposColetaveis != null)
        {
            foreach (TipoRecurso t in tiposColetaveis)
            {
                if (t == tipo)
                {
                    return true;
                }
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

    public IEnumerator IniciarColetaRecursoParaDeposito(FonteRecurso fonte,Deposito deposito)
    {
        if (IsColetorDe(fonte.tipo))
        {
            Atividades anterior = _atividade.atividade;
            while (!fonte.EstaVazio)
            {
                if (quantidadeRecursoAtual == 0 || recursoAtual == fonte.tipo)
                {
                    _atividade.atividade = Atividades.colhendo;
                    yield return StartCoroutine(_movel.MoverQualquerCustoPara(fonte.transform));
                    while (!EstaCheio())
                    {
                        yield return new WaitForSeconds(1);
                        if (!ColherRecurso(fonte)) { break; }
                    }
                    recursoAtual = fonte.tipo;
                }
                _atividade.atividade = Atividades.carregando;
                if (deposito == null)
                {
                    print("Parando IniciarColetaRecurso");
                    _atividade.atividade = Atividades.esperando;
                    StopAllCoroutines();
                }
                yield return StartCoroutine(_movel.MoverQualquerCustoPara(deposito.transform));
                quantidadeRecursoAtual -= deposito.DepositarRecurso(quantidadeRecursoAtual);
            }
            _atividade.atividade = anterior;
        }
    }

    //public IEnumerator IniciarColetaRecurso(FonteRecurso fonte)
    //{
    //    if (IsColetorDe(fonte.tipo))
    //    {
    //        while (!fonte.EstaVazio)
    //        {
    //            if (quantidadeRecursoAtual == 0 || recursoAtual == fonte.tipo)
    //            {
    //                _atividade.atividade = Atividades.colhendo;
    //                yield return StartCoroutine(_movel.MoverQualquerCustoPara(fonte.transform));
    //                while (!EstaCheio())
    //                {
    //                    yield return new WaitForSeconds(1);
    //                    if (!ColherRecurso(fonte)) { break; }
    //                }
    //                recursoAtual = fonte.tipo;
    //            }
    //            _atividade.atividade = Atividades.carregando;
    //            Deposito depositoProximo = ControlePartida.ObterJogador(idJogador).ObterDepositoRecursoMaisProximo(recursoAtual, transform.position);
    //            if (depositoProximo == null)
    //            {
    //                print("Parando IniciarColetaRecurso");
    //                _atividade.atividade = Atividades.esperando;
    //                StopAllCoroutines();
    //            }
    //            yield return StartCoroutine(_movel.MoverQualquerCustoPara(depositoProximo.transform));
    //            quantidadeRecursoAtual -= depositoProximo.DepositarRecurso(quantidadeRecursoAtual);
    //        }
    //    }
    //}
}
