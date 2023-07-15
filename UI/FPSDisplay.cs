using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FPStext;

    private float pollingTime = .5f;
    private float time;
    private int frameCount;

   void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if (time >= pollingTime)
        {
            int framerate = Mathf.RoundToInt(frameCount/time);
            FPStext.text = framerate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
