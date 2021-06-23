using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Evento entrarFotografia;
    [SerializeField] Evento sairFotografia;
    public void AlterarModo() {
        if(EstadoJogo.modoFotografia == true) {
            EstadoJogo.modoFotografia = false;
            sairFotografia.Ocorrido();
        } else {
            EstadoJogo.modoFotografia = true;
            entrarFotografia.Ocorrido();
        }
        Debug.Log("Modo fotografia" + EstadoJogo.modoFotografia.ToString());
    }
}
