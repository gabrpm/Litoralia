using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorCamera : MonoBehaviour
{
    [SerializeField] SpriteRenderer cruz;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Especie") || other.gameObject.CompareTag("Jogador")) {
            cruz.color = Color.green;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Especie") || other.gameObject.CompareTag("Jogador")) {
            cruz.color = Color.white;
        }
    }
    
}
