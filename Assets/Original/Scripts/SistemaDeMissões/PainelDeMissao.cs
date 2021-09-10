using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelDeMissao : MonoBehaviour
{
    [SerializeField] Missao missao;
    [SerializeField] TextMeshProUGUI letreiroTitulo;
    [SerializeField] TextMeshProUGUI letreiroDescricao;
    [SerializeField] TextMeshProUGUI letreiroProgresso;
    [SerializeField] GameObject sliderProgresso;

    private void Update() {
        Atualizar();
    }

    public void AtribuirMissao(Missao m) {
        missao = m;
        Atualizar();
    }
    
    public void Atualizar() {
        letreiroTitulo.text = missao.Nome;
        letreiroDescricao.text = missao.Descricao;
        sliderProgresso.GetComponent<Slider>().value = missao.Progresso;
        int porcento = (int)(missao.Progresso * 100);
        letreiroProgresso.text = porcento.ToString() + "%";
        }

}
