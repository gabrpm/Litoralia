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
        EstadoJogo.quantidadeTotalSp = colecaoDeEspecies.ListaDeEspecies.Count;
    }

    public void DisponibilizarNaColecao(Especie sp) {
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
        EstadoJogo.colecaoAberta = true;
        AtualizarQtde();
        evento_AbrirColecao.Ocorrido();
    }

    public void FecharColecao() {
        EstadoJogo.colecaoAberta = false;
        evento_FecharColecao.Ocorrido();
    }

    public void MostrarPainelDeInformacoes(Especie sp) {
        painelDeInfo.SetActive(true);
        letreiroNomeComum.text = sp.NomeComum;
        letreiroNomeCientifico.text = sp.NomeCientifico;
        letreiroOcorrencia.text = sp.OcorrenciaNaNatureza;
        letreiroRisco.text = sp.GrauDeAmeaca.ToString();
        letreiroFrase.text = sp.Frase;
        imagemNatureza.sprite = sp.ImagemNaNatureza;
        imagemJogo.sprite = null;
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
        return i;
    }

}
