using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovimentacaoJogador : MonoBehaviour
{   

    [Tooltip("Quão rápido o personagem se move?")]
    [Range(2,15)]
    [SerializeField] float velocidade = 5;
    Vector2 direcao;
    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {

        if(GerenciadorDeDialogos.DialogoAtivo) {
            return;
        }

        if(!EstadoJogo.modoFotografia && !EstadoJogo.colecaoAberta) {
            Mover();
        }
        
    }
    public void DefinirDirecao(Vector2 para) {
        direcao.x = para.x;
        direcao.y = para.y;
    }

    void Mover() {
        rb.MovePosition(rb.position + direcao * velocidade * Time.fixedDeltaTime);
    }
}
