using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosDoJogador : Singleton<DadosDoJogador>
{
    public static Color cor = Color.white;

    private void Awake() {
        cor = GetComponent<SpriteRenderer>().color;
    }
    
}
