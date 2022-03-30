using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementoDeColecao : MonoBehaviour
{
    public Especie item;
    private Image image;
    private Button button;

    private void Awake() {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
    public void Atualizar() {
        image.sprite = item.ImagemNoJogo;
        image.preserveAspect = true;
        
        if(!item.disponivelNaColecao) {
            image.color = Color.black;
            button.interactable = false;
        } else {
            image.color = Color.white;
            button.interactable = true;
        }

    }
    
    public void MostrarInformações() {
        GerenciadorDeColecoes.instancia.MostrarPainelDeInformacoes(item);
    }
}
