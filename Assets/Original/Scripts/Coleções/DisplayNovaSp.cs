using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayNovaSp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI letreiroNomeComum;
    [SerializeField] TextMeshProUGUI letreiroBinomio;
    [SerializeField] Image imagemSp;

    public IEnumerator ExibirPopUpNovaSp(Especie novaSp) {
        letreiroNomeComum.text = novaSp.NomeComum;
        letreiroBinomio.text = novaSp.NomeCientifico;
        imagemSp.sprite = novaSp.ImagemNoJogo;
        imagemSp.preserveAspect = true;

        LeanTween.moveY(GetComponent<RectTransform>(), 138f, 1f);
        yield return new WaitForSeconds(6f);
        LeanTween.moveY(GetComponent<RectTransform>(), -138f, 1f);
    }

    public void IniciarCorotinaNovaSp(Especie sp) {
        StartCoroutine(ExibirPopUpNovaSp(sp));
    }
}
