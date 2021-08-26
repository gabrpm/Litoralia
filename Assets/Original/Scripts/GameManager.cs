using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Evento evento_EntrarFotografia;
    [SerializeField] Evento evento_SairFotografia;

    public void AlterarModo() {
        if(GerenciadorDeDialogos.DialogoAtivo) {
            return;
        }

        if(EstadoJogo.colecaoAberta) {
            return;
        }
        
        if(EstadoJogo.modoFotografia == true) {
            evento_SairFotografia.Ocorrido();
            EstadoJogo.modoFotografia = false;
        } else {
            evento_EntrarFotografia.Ocorrido();
            EstadoJogo.modoFotografia = true;
        }
    }
}
