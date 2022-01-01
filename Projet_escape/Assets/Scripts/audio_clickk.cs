using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_clickk : MonoBehaviour
{
    [SerializeField] private AudioSource click_sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSound()
    {
        click_sound.PlayScheduled(1f);
        //Debug.Log("ok");
    }
}
