using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelDeDados : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI letreiroNome;
    [SerializeField] TextMeshProUGUI letreiroQtdPessoas;
    [SerializeField] TextMeshProUGUI letreiroQtdSpp;
    [SerializeField] Image sprite;

    private void Update()
    {

        AtualizarPainel();
    }

    public void AtualizarPainel()
    {
        letreiroNome.text = DadosDoJogador.instancia.Nome;
        letreiroQtdPessoas.text = GerenciadorDeDialogos.instancia.PessoasConversadas.ToString();
        letreiroQtdSpp.text = GerenciadorDeColecoes.instancia.QtdeDeSpRegistradas().ToString();
        sprite.color = DadosDoJogador.instancia.Cor;
    }
}
