using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Conversador : MonoBehaviour, IPointerDownHandler
{
    [SerializeReference] protected VIDE_Assign dialogo;
    [SerializeField] protected Pessoa dialogador;
    [SerializeField] protected TextAsset conversaPadrao;

    public Pessoa Dialogador { get { return dialogador; } }
    void Awake()
    {
        dialogo = GetComponent<VIDE_Assign>();
        dialogo.AssignNew(conversaPadrao.name);
    }
    
    public void SerConscientizado() {
        dialogador.Conscientizar();
    }
    
    virtual public void OnPointerDown (PointerEventData eventData) {
        if(eventData.button.ToString() == "Right") {
            return;
        }
        if(!EstadoJogo.modoFotografia){

            GerenciadorDeDialogos.instancia.IniciarDialogo(dialogo);
        }
    }

}
