using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public bool habilitar;
    public bool holdMovimento;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        direcaoMouse = transform.position;
    }
    private void FixedUpdate() {
        
        if(holdMovimento)
        {
            HoldMover();
        }
        else
        {
            Mover();
        }
             
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
        DefinirDirecaoMouse(transform.position);
        habilitar = habil;
    }

    public void HoldMover()
    {
        DefinirDirecaoMouse(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        transform.position = Vector2.MoveTowards(transform.position, direcaoMouse, (velocidade - 2) * Time.fixedDeltaTime);
    }
}
