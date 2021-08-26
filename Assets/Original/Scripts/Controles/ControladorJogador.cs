using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

//Esse componente necessita desses outros para funcionar corretamente:
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(MovimentacaoJogador))]


//Esta classe é responsável por captar o input dado pelo jogador e chamar as funções
//que controlam o jogador nos scripts necessários.
public class ControladorJogador : MonoBehaviour
{
    InputActions controles;
    [SerializeField] PlayerInput input;
    [SerializeField] MovimentacaoJogador scriptMovimentacao;
    [SerializeField] ComportamentoCamera scriptCamera;
    [SerializeField] InteracaoJogador scriptInteracao;
    void Awake()
    {
        controles = new InputActions();
        input.onActionTriggered += Input_onActionTriggered;
    }

    void OnDisable() {
        input.onActionTriggered -= Input_onActionTriggered;
    }
    

    //Sempre que uma ação é realizada, as funções de controle são chamadas.
    private void Input_onActionTriggered(InputAction.CallbackContext obj) {

        //Primeiro devem vir os comandos de vetores.
        if (obj.action.name == controles.Jogador.Mover.name) {
            scriptMovimentacao.mouse = false;
            scriptMovimentacao.DefinirDirecaoTeclado(obj.ReadValue<Vector2>());
        }

        if (obj.action.name == controles.Jogador.Olhar.name) {
            scriptCamera.AjustarPosicaoMouse(obj.ReadValue<Vector2>());
        }

        //Esta checagem impede que os comandos sejam lidos mais de uma vez.
        if(!obj.performed) {
            return;
        }

        //Agora devem vir os comandos de botões.
        
        if(obj.action.name == controles.Jogador.MoverPara.name) {
            scriptMovimentacao.mouse = true;
            scriptMovimentacao.DefinirDirecaoMouse(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
        
        if (obj.action.name == controles.Jogador.ModoFotografia.name) {
            GameManager.instancia.AlterarModo();
        }

        if (obj.action.name == controles.Jogador.TirarFoto.name) {
            scriptCamera.Fotografar();
        }

        if (obj.action.name == controles.Jogador.Colecao.name) {
            
            if(!EstadoJogo.colecaoAberta) {
                GerenciadorDeColecoes.instancia.AbrirColecao(); }
            else {
                GerenciadorDeColecoes.instancia.FecharColecao();
            }
        }

        if(obj.action.name == controles.Jogador.Interagir.name) {
            scriptInteracao.Interagir();
        }

        if(obj.action.name == controles.Jogador.FecharJogo.name) {
            Application.Quit();
        }
    }
}
