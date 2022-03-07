using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelDeDados : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI letreiroNome;
    [SerializeField] TextMeshProUGUI letreiroLvl;
    [SerializeField] Image sprite;

    private void Update()
    {
        AtualizarPainel();
    }

    public void AtualizarPainel()
    {
        letreiroNome.text = DadosDoJogador.instancia.Nome;
        letreiroLvl.text = DadosDoJogador.instancia.Lvl.ToString();
        sprite.color = DadosDoJogador.instancia.Cor;
    }
}
