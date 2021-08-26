using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovimentacaoJogador : MonoBehaviour
{   

    [Tooltip("Quão rápido o personagem se move?")]
    [Range(2,15)]
    [SerializeField] float velocidade = 5;
    [SerializeField] Vector2 direcaoTeclado;
    [SerializeField] Vector2 direcaoMouse;
    Rigidbody2D rb;
    public bool mouse;
    public bool habilitar = true;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
            Mover();        
    }
    
    public void DefinirDirecaoMouse(Vector2 para) {

        if(habilitar) {
            direcaoMouse.x = para.x;
            direcaoMouse.y = para.y;
        }
    }
    
    public void DefinirDirecaoTeclado(Vector2 para) {

        if(habilitar) {
            direcaoTeclado.x = para.x;
            direcaoTeclado.y = para.y;
        }
    }

    void Mover() {
        if(!mouse) {
            rb.MovePosition(rb.position + direcaoTeclado * velocidade * Time.fixedDeltaTime);
            DefinirDirecaoMouse(transform.position);
        } else{
            transform.position = Vector2.MoveTowards(transform.position, direcaoMouse, velocidade * Time.fixedDeltaTime);
        }
    }

    public void HabilitarMovimentacao(bool habil) {
        habilitar = habil;
    }
}
