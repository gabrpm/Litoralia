using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OuvinteEvento : MonoBehaviour
{
    [Tooltip("Aqui deve-se atribuir algum evento (Assets/Events) para que o objeto escute. A função a ser executada assim que o evento seja ouvido deve ser escolhida em Resposta().")]
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
