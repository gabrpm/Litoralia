using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DadosDoJogador : Singleton<DadosDoJogador>
{
    private string nome;
    private int pessoasEncontradas;
    private int sppEncontradas;
    private Color cor = Color.white;
    [SerializeField] private SpriteRenderer[] spritesPersonagem = new SpriteRenderer[3];
    private string pronome;

    public Color Cor { get { return cor; } }
    public int SppEncontradas { get { return sppEncontradas; } }
    public int PessoasEncontradas { get { return pessoasEncontradas; } }
    public string Nome { get { return nome; } }
    public string Pronome { get { return pronome; } }


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
        //Debug.Log(nome);
    }

    public void AlterarPronome(string pn)
    {
        pronome = pn;
    }

    public void AlterarCor(Image img)
    {
        cor = img.color;
        for (int i = 0; i<spritesPersonagem.Length; i++)
        {
            spritesPersonagem[i].color = cor;
        }
    }
    
}
