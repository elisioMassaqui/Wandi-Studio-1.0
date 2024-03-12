using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReorderManager : MonoBehaviour
{
    // Lista de elementos
    public List<string> elementos = new List<string> { "A", "B", "C", "D", "E" };

    // Lista de botões associados aos elementos
    public List<Toggle> botoes;

    // Text para exibir a nova ordem
    public Text textoOrdem;

    void Update(){
        AtualizarOrdem();
    }

    // Atualiza a ordem quando os botões são marcados ou desmarcados
    public void AtualizarOrdem()
    {
        // Obtém os índices dos elementos marcados
        List<int> indicesMarcados = new List<int>();

        for (int i = 0; i < botoes.Count; i++)
        {
            if (botoes[i].isOn)
            {
                indicesMarcados.Add(i);
            }
        }

        // Reorganiza a lista com base nos índices marcados
        List<string> novaOrdem = indicesMarcados.ConvertAll(i => elementos[i]);

        // Exibe a nova ordem (isso pode ser ajustado conforme necessário)
        Debug.Log("Nova Ordem: " + string.Join(", ", novaOrdem));

         // Atualiza o Text com a nova ordem
        textoOrdem.text = "Nova Ordem: " + string.Join(", ", novaOrdem);
    }
}
