using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myVideoPlayer.loopPointReached += DoSomethingWhenVideoFinish;
    }

    void DoSomethingWhenVideoFinish(VideoPlayer vp)
    {
        //Debug.Log("Video Ended");
        SceneManager.LoadScene("Game");
        //SaveManager.Instance.StartLoadedGame(1);

    }
}
