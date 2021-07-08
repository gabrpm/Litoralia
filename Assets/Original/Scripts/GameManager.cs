using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Evento evento_EntrarFotografia;
    [SerializeField] Evento evento_SairFotografia;

    public void AlterarModo() {
        if(EstadoJogo.modoFotografia == true) {
            EstadoJogo.modoFotografia = false;
            evento_SairFotografia.Ocorrido();
        } else {
            EstadoJogo.modoFotografia = true;
            evento_EntrarFotografia.Ocorrido();
        }
    }
}
