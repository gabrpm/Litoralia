using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoCamera : MonoBehaviour
{
    Vector2 posicaoMouse;
    [SerializeField] Transform personagem;
    [SerializeField] Evento eventoFotografar;

    void Update()
    {
        if(EstadoJogo.modoFotografia) {
            SeguirCursor();
        }

        ClampearVisor();
        
    }

    public void SeguirCursor() {
        float posX = Camera.main.ScreenToWorldPoint(posicaoMouse).x;
        float posY = Camera.main.ScreenToWorldPoint(posicaoMouse).y;
        
        transform.position = new Vector3(posX, posY, 0);

        //Debug.Log("X: " + posX.ToString() + " Y: " + posY.ToString());
    }

    public void ClampearVisor() {
        float posX = transform.position.x;
        float posY = transform.position.y;
        
        if(posX - personagem.position.x > 9f){
            posX = 9f + personagem.position.x;
        } else if(posX - personagem.position.x < -9f) {
            posX = -9f + personagem.position.x;
        }

        if (posY - personagem.position.y > 5f) {
            posY = 5f  + personagem.position.y;
        } else if (posY - personagem.position.y <-5f) {
            posY = -5f + personagem.position.y;
        }

        transform.position = new Vector3 (posX,posY,0);

    }

    public void AjustarPosicaoMouse(Vector2 pos) {
        posicaoMouse = pos;
    }

    public void MostrarVisor(bool b) {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (!b) {
           sr.color = new Color (0,0,0,0);
        } else {
            sr.color = Color.black;
        }
    }

    public void Fotografar() {
        if(EstadoJogo.modoFotografia) {
            eventoFotografar.Ocorrido();
            Debug.Log("Foto tirada!");
        }
        
    }

}
