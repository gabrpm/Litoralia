using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OuvinteEvento : MonoBehaviour
{
    public Evento evento;
    public UnityEvent resposta;

    private void OnEnable() {
        evento.Registrar(this);
    }

    private void OnDisable() {
        evento.Desregistrar(this);
    }

    public void AoOcorrerEvento() {
        resposta.Invoke();
    }
}
