using UnityEngine;
using UnityEngine.Video;

public class VideoToFrames : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int framesPerSecond = 30;
    public string outputFolder = "Frames";

    private void Start()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.waitForFirstFrame = true;
        videoPlayer.isLooping = false;

        ExtractFrames();
    }

    private void ExtractFrames()
    {
        if (!System.IO.Directory.Exists(outputFolder))
        {
            System.IO.Directory.CreateDirectory(outputFolder);
        }

        float videoLength = (float)videoPlayer.frameCount / videoPlayer.frameRate;

        for (float time = 0; time < videoLength; time += 1f / framesPerSecond)
        {
            videoPlayer.time = (double)time;
            videoPlayer.Pause();

            RenderTexture renderTexture = new RenderTexture(videoPlayer.targetTexture);
            videoPlayer.targetTexture = renderTexture;

            Texture2D frame = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            RenderTexture.active = renderTexture;
            frame.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            frame.Apply();

            byte[] bytes = frame.EncodeToPNG();
            System.IO.File.WriteAllBytes($"{outputFolder}/frame_{(int)(time * framesPerSecond)}.png", bytes);

            RenderTexture.active = null;
            Destroy(renderTexture);
        }

        Debug.Log("Frames extracted successfully!");
    }
}
