using UnityEngine;

// Singleton genérico utilizado para gerar outros tipos de Singleton
public class Singleton<T> : MonoBehaviour  where T : MonoBehaviour {

    // A instância do singleton que será utilizado. A instância não deve ser alterada por
    // elementos externos
    protected static T _instancia;

    // Controla o acesso em situações onde o objeto está em processo de ser destruído ou ja foi destruído
    private static bool desligando;

    public static T instancia { 
        get {
            // Verifica se o obejto foi destruído e avisa caso tenha acontecido
            if(desligando) {
                Debug.LogWarning("A instância do objeto " + typeof(T) + " já foi destruída");
                return null;
            }
            // Verifica se já há, em algum lugar, uma instância do singleton
            if(_instancia == null) {
                _instancia = (T) FindObjectOfType(typeof(T));
                // Caso não exista, cria um objeto e liga-a a singleton a ele
                // O objeto não deve ser destruído 
                if(_instancia == null) {
                    // Para melhor identificação o nome do objeto é definido como o da
                    // Singleton
                    GameObject go = new GameObject(typeof(T).ToString() + " (Singleton)");
                    _instancia = (T) go.AddComponent(typeof(T));
                    DontDestroyOnLoad(go);    
                }
                
            }
            return _instancia;
            }
    }
    
    protected Singleton() {
        desligando = false;
    }

    private void OnApplicationQuit() {
        desligando = true;
    }

    private void OnDestroy() {
        desligando = true;
    }
}