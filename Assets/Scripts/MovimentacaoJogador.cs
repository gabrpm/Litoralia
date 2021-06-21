using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Esse componente necessita desses outros para funcionar corretamente:
[RequireComponent(typeof(ControladorJogador))]
public class MovimentacaoJogador : MonoBehaviour
{   

    [Tooltip("Quão rápido o personagem se move?")]
    [Range(2,15)]
    [SerializeField] float velocidade = 5;
    Vector2 direcao;

    private void FixedUpdate() {

        Mover();
    
    }
    public void DefinirDirecao(Vector2 para) {
        direcao = para;
    }

    void Mover() {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
