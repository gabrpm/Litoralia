using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorDeColecoes : Singleton<GerenciadorDeColecoes>
{

    public ColecaoDeEspecies colecaoDeEspecies;
    [SerializeField] Evento evento_AbrirColecao;
    [SerializeField] Evento evento_FecharColecao;
    [SerializeField] GameObject painelDeInfo;
    [SerializeField] TextMeshProUGUI letreiroQtde;
    [SerializeField] TextMeshProUGUI letreiroNomeComum;
    [SerializeField] TextMeshProUGUI letreiroNomeCientifico;
    [SerializeField] TextMeshProUGUI letreiroOcorrencia;
    [SerializeField] TextMeshProUGUI letreiroRisco;
    [SerializeField] TextMeshProUGUI letreiroFrase;
    [SerializeField] Image imagemNatureza;
    [SerializeField] Image imagemJogo;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        EstadoJogo.quantidadeTotalSp = colecaoDeEspecies.ListaDeEspecies.Count;
    }

    public void DisponibilizarNaColecao(Especie sp) {
        Debug.Log("GColecoes sendo chamado");
        foreach (Especie especie in colecaoDeEspecies.ListaDeEspecies)
        {
            if(especie.NomeComum == sp.NomeComum) {
                especie.disponivelNaColecao = true;
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
        letreiroOcorrencia.text = sp.OcorrenciaNaNatureza;
        letreiroRisco.text = sp.GrauDeAmeaca.ToString();
        letreiroFrase.text = sp.Frase;
        imagemNatureza.sprite = sp.ImagemNaNatureza;
        imagemNatureza.preserveAspect = true;
        imagemJogo.sprite = sp.ImagemNoJogo;
        imagemJogo.preserveAspect = true;
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

}
