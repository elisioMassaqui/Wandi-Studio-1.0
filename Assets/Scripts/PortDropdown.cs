using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using TMPro;

public class PortDropdown : MonoBehaviour
{
    public TMP_Dropdown portDropdown;
    public TextMeshProUGUI portaSelecionada;

    void Start()
    {
        AtualizarPortas();
    }

    void Update()
    {
       
    }

      // Atualiza a lista de portas e o dropdown
    public void AtualizarPortas()
    {
        // Obter a lista de portas disponíveis
        string[] ports = SerialPort.GetPortNames();

        // Limpar as opções existentes no dropdown
        portDropdown.ClearOptions();

        // Adicionar as portas detectadas como opções no dropdown
        portDropdown.AddOptions(new List<string>(ports));

        // Adicionar um listener para o evento de seleção do dropdown
        portDropdown.onValueChanged.AddListener(OnPortDropdownValueChanged);
    }

    // Manipula a mudança na seleção do dropdown
    private void OnPortDropdownValueChanged(int index)
    {
        string selectedPort = portDropdown.options[index].text;
        Debug.Log("Porta selecionada: " + selectedPort);
        portaSelecionada.text = selectedPort;

        // Você pode fazer o que quiser com a porta selecionada, como iniciar a comunicação serial, etc.
    }
}
