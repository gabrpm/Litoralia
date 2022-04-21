using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorDeColecoes : Singleton<GerenciadorDeColecoes>
{

    public ColecaoDeEspecies colecaoDeEspecies;
    [SerializeField] List<PainelDeColecao> listaDePaineis = new List<PainelDeColecao>();
    [SerializeField] int indicePainelAtual = 0;

    [Header("Parâmetros")]
    [SerializeField] int elementosPorPagina = 15;

    [Header("Eventos")]
    [SerializeField] Evento evento_AbrirColecao;
    [SerializeField] Evento evento_FecharColecao;

    [Header("GOs referenciados")]
    [SerializeField] GameObject painelDeInfo;
    [SerializeField] GameObject colecao;
    [SerializeField] DisplayNovaSp displayNovaSp;

    [Header("Letreiros")]
    [SerializeField] TextMeshProUGUI letreiroQtde;
    [SerializeField] TextMeshProUGUI letreiroNomeComum;
    [SerializeField] TextMeshProUGUI letreiroNomeCientifico;
    [SerializeField] TextMeshProUGUI letreiroOcorrencia;
    [SerializeField] TextMeshProUGUI letreiroRisco;
    [SerializeField] TextMeshProUGUI letreiroFrase;
    [SerializeField] TextMeshProUGUI letreiroReino;
    [SerializeField] TextMeshProUGUI letreiroFilo;
    [SerializeField] TextMeshProUGUI letreiroClasse;
    [SerializeField] TextMeshProUGUI letreiroOrdem;
    [SerializeField] TextMeshProUGUI letreiroFamilia;
    [SerializeField] TextMeshProUGUI letreiroGenero;

    [Header("ImagensUI")]
    [SerializeField] Image imagemNatureza;
    [SerializeField] Image imagemJogo;
    [SerializeField] Image imagemAmeaca;

    [Header("Sprites de Categorias")]
    [SerializeField] List<Sprite> listaCategorias = new List<Sprite>();

    [Header("Prefabs")]
    [SerializeField] GameObject painelItens_pfab;
    [SerializeField] GameObject elementoDeColecao_pfab;
    

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        EstadoJogo.quantidadeTotalSp = colecaoDeEspecies.ListaDeEspecies.Count;
        AjustarPaineisAColecao();
        colecao.SetActive(false);
    }

    public void DisponibilizarNaColecao(Especie sp) {
        Debug.Log("GColecoes sendo chamado");
        foreach (Especie especie in colecaoDeEspecies.ListaDeEspecies)
        {
            if(especie.NomeComum == sp.NomeComum) {
                especie.disponivelNaColecao = true;
                displayNovaSp.IniciarCorotinaNovaSp(especie);
                return;
            }
        }
        Debug.LogWarning("Espécie não encontrada.");
    }

    public void AbrirColecao() {

        if(EstadoJogo.modoFotografia) {
            return;
        }

        if(GerenciadorDeDialogos.DialogoAtivo) {
            return;
        }
        evento_AbrirColecao.Ocorrido();

        colecao.SetActive(true);
        listaDePaineis[indicePainelAtual].gameObject.SetActive(true);

        EstadoJogo.colecaoAberta = true;
        AtualizarQtde();
        
        
    }

    public void FecharColecao() {
        
        evento_FecharColecao.Ocorrido();
        EstadoJogo.colecaoAberta = false;
    }

    public void MostrarPainelDeInformacoes(Especie sp) {
        painelDeInfo.SetActive(true);
        letreiroNomeComum.text = sp.NomeComum;
        letreiroNomeCientifico.text = sp.NomeCientifico;
        letreiroReino.text = sp.Reino;
        letreiroFilo.text = sp.Filo;
        letreiroClasse.text = sp.Classe;
        letreiroOrdem.text = sp.Ordem;
        letreiroFamilia.text = sp.Familia;
        letreiroGenero.text = sp.Genero;
        letreiroOcorrencia.text = sp.OcorrenciaNaNatureza;
        letreiroRisco.text = RetornarTextoDeCategoria(sp.GrauDeAmeaca);
        imagemAmeaca.sprite = listaCategorias[(int)sp.GrauDeAmeaca];
        letreiroFrase.text = sp.Frase;
        imagemNatureza.sprite = sp.ImagemNaNatureza;
        imagemNatureza.preserveAspect = true;
        imagemJogo.sprite = sp.ImagemNoJogo;
        imagemJogo.preserveAspect = true;
    }

    public string RetornarTextoDeCategoria(RiscoDeExtincao categoria)
    {
        if (categoria == RiscoDeExtincao.N_AVALIADA) return "Não Avaliada (NE)";
        else if (categoria == RiscoDeExtincao.N_APLICAVEL) return "Não Aplicável (NA)";
        else if (categoria == RiscoDeExtincao.DADOS_INSUFICIENTES) return "Dados Insuficientes (DD)";
        else if (categoria == RiscoDeExtincao.POUCO_PREOCUPANTE) return "Menos Preocupante (LC)";
        else if (categoria == RiscoDeExtincao.QUASE_AMEACADA) return "Quase Ameaçada (NT)";
        else if (categoria == RiscoDeExtincao.VULNERAVEL) return "Vulnerável (VU)";
        else if (categoria == RiscoDeExtincao.EM_PERIGO) return "Em Perigo (EN)";
        else if (categoria == RiscoDeExtincao.CRITICAMENTE_AMEACADA) return "Criticamente em Perigo (CR)";
        else if (categoria == RiscoDeExtincao.REGIONALMENTE_EXTINTA) return "Regionalmente Extinta (RE)";
        else if (categoria == RiscoDeExtincao.EXTINTA_NA_NATUREZA) return "Extinta na Natureza (EW)";
        else return "Extinta (EX)";

    }

    public void AtualizarQtde() {
        EstadoJogo.quantidadeRegistradaSp = QtdeDeSpRegistradas();
        letreiroQtde.text = EstadoJogo.quantidadeRegistradaSp.ToString() + "/" + EstadoJogo.quantidadeTotalSp.ToString();
    }
    
    public int QtdeDeSpRegistradas() {
        int i = 0;
        foreach (Especie sp in colecaoDeEspecies.ListaDeEspecies) {
            if(sp.disponivelNaColecao) {
                i++;
            }
        }
        //Debug.Log("Todos" + i.ToString());
        return i;
    }
    public int QtdeDeSpRegistradas(Ecossistema eco) {

        if(eco == Ecossistema.TODOS) return QtdeDeSpRegistradas();
        
        int i = 0;
        foreach (Especie sp in colecaoDeEspecies.ListaDeEspecies) {
            if(sp.disponivelNaColecao) {
                if(eco == Ecossistema.MAR && sp.OcorreNoMar) {
                    i++;
                } else if (eco == Ecossistema.COSTA && sp.OcorreNaCosta) {
                    i++;
                } else if (eco == Ecossistema.ESTUARIO && sp.OcorreNoEstuario) {
                    i++;
                }
            }
        }
        //Debug.Log(eco.ToString() + i.ToString());
        return i;
    }

    public void AjustarPaineisAColecao()
    {
        GameObject go_pItens = Instantiate(painelItens_pfab,colecao.transform);
        listaDePaineis.Add(go_pItens.GetComponent<PainelDeColecao>());
        GameObject go_elemento;
        foreach (Especie sp in colecaoDeEspecies.ListaDeEspecies)
        {
            if(go_pItens.transform.childCount >= elementosPorPagina)
            {
                go_pItens.SetActive(false);
                go_pItens = Instantiate(painelItens_pfab, colecao.transform);
                listaDePaineis.Add(go_pItens.GetComponent<PainelDeColecao>());
            }

            go_elemento = Instantiate(elementoDeColecao_pfab, go_pItens.transform);
            go_elemento.GetComponent<ElementoDeColecao>().item = sp;
            go_elemento.GetComponent<ElementoDeColecao>().Atualizar();
            go_pItens.transform.SetSiblingIndex(0);
        }
        go_pItens.SetActive(false);
        
    }

    public void PassarPg(int para) 
    {
        if (para > 0)
        {
            if (indicePainelAtual >= listaDePaineis.Count - 1) return;
            listaDePaineis[indicePainelAtual+1].gameObject.SetActive(true);
            listaDePaineis[indicePainelAtual+1].MoverPara(1800f, 0);
            listaDePaineis[indicePainelAtual+1].MoverPara(0, 0.5f);
            listaDePaineis[indicePainelAtual].MoverPara(-1800f, 0.5f);
            indicePainelAtual++;
            

        } else if (para < 0) {
            if (indicePainelAtual == 0) return;
            listaDePaineis[indicePainelAtual - 1].gameObject.SetActive(true);
            listaDePaineis[indicePainelAtual - 1].MoverPara(0, 0.5f);
            listaDePaineis[indicePainelAtual].MoverPara(1800f, 0.5f);
            
            indicePainelAtual--;
        }
    }

}
