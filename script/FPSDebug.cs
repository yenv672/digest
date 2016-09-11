using UnityEngine;
using UnityEngine.UI;

public class FPSDebug : MonoBehaviour
{

    //TextMesh components
    [SerializeField]
    TextMesh myFPSTextMesh;
    [SerializeField]
    TextMesh myAVGTextMesh;
    [SerializeField]
    TextMesh myHITextMesh;
    [SerializeField]
    TextMesh myLOWTextMesh;

    //GUI Text components
    [SerializeField]
    Text myFPSText;
    [SerializeField]
    Text myAVGText;
    [SerializeField]
    Text myHIText;
    [SerializeField]
    Text myLOWText;

    [SerializeField]
    int frameRange = 60;

    int[] fpsBuffer;
    int fpsBufferIndex;

    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    void Start()
    {
    }

    void Update()
    {
        UpdateTextMesh();
        UpdateGUIText();

        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
        {
            InitializeBuffer();
        }

        UpdateBuffer();
        CalculateFPS();
    }

    void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }

        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);

        if (fpsBufferIndex >= frameRange)
        {
            fpsBufferIndex = 0;
        }
    }

    void UpdateTextMesh()
    {
        if (myFPSTextMesh != null)
            myFPSTextMesh.text = "Current FPS: " + (1 / Time.unscaledDeltaTime).ToString("F");

        if (myAVGTextMesh != null)
            myAVGTextMesh.text = "Average FPS: " + AverageFPS;

        if (myLOWTextMesh != null)
            myLOWTextMesh.text = "Lowest FPS: " + LowestFPS;

        if (myHITextMesh != null)
            myHITextMesh.text = "Highest FPS: " + HighestFPS;
    }

    void UpdateGUIText()
    {
        if (myFPSText != null)
            myFPSText.text = "Current FPS: " + (1 / Time.unscaledDeltaTime).ToString("F");

        if (myAVGText != null)
            myAVGText.text = "Average FPS: " + AverageFPS;

        if (myLOWText != null)
            myLOWText.text = "Lowest FPS: " + LowestFPS;

        if (myHIText != null)
            myHIText.text = "Highest FPS: " + HighestFPS;
    }

    void CalculateFPS()
    {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;
        for (int i = 0; i < frameRange; i++)
        {
            int fps = fpsBuffer[i];
            sum += fps;
            if (fps > highest)
            {
                highest = fps;
            }
            if (fps < lowest)
            {
                lowest = fps;
            }
        }
        AverageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }
}
