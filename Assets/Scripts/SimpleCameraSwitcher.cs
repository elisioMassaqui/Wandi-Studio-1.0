using TMPro;
using UnityEngine;

public class SimpleCameraSwitcher : MonoBehaviour
{
    public TMP_Text camerasTextUI;
    public Camera[] cameras; // Lista das quatro câmeras
    private int currentCameraIndex = 0;

    void Start()
    {
        // Garante que pelo menos uma câmera está ativa
        if (cameras.Length > 0)
        {
            SwitchCamera(currentCameraIndex);
        }
    }

    void Update()
    {
       
    }

    public void alterarCameraButton(){
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        SwitchCamera(currentCameraIndex);
    }

    void SwitchCamera(int newIndex)
    {
        // Desativa todas as câmeras na lista
        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }

        // Ativa a câmera correspondente ao índice newIndex
        cameras[newIndex].enabled = true;

        camerasTextUI.text = "Camera.Atual : " + cameras[newIndex].name;
    }
}
