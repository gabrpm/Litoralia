using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DadosDoJogador : Singleton<DadosDoJogador>
{
    private string nome;
    private int lvl;
    private Color cor = Color.white;

    public Color Cor { get { return cor; } }
    public int Lvl { get { return lvl; } }
    public string Nome { get { return nome; } }


    private void Awake() {
        cor = GetComponentInChildren<SpriteRenderer>().color;
    }

    public void MudarCor(Color c)
    {
        cor = c;
    }

    public void AlterarNome(string n)
    {
        nome = n;
    }
    
    public void AlterarNomeAPartirDeTMPro(TextMeshProUGUI texto)
    {
        nome = texto.text;
        Debug.Log(nome);
    }
    
}
