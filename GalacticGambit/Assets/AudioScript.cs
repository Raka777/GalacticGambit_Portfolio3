using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("Music to continuously play in the game")]
    [SerializeField]
    AudioSource source;
    [Header("Play When player gets close to the wormhole")]
    [SerializeField]
    AudioSource source2;


    // Start is called before the first frame update
    void Start()
    {
        source2.playOnAwake = false;
        source2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
