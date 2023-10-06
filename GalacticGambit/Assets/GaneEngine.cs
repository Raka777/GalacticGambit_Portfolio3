using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneEngine : MonoBehaviour
{
    public Canvas canvas;
    //The music stops on pause
    public GameObject AudioContainer;
    public AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = AudioContainer.GetComponentsInChildren<AudioSource>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) == true)
        {
            if (Time.timeScale == 1)
            { 
                Time.timeScale = 0;
                canvas.enabled = true;
                AudioControls(false);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                canvas.enabled = false;
                AudioControls(true);
            }
        }
    }

    public void AudioControls(bool IsAudioPlaying)
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].enabled = IsAudioPlaying;
        }
    }
}
