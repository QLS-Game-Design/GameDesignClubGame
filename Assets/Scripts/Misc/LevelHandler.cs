using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public AudioClip level1audio;
    public AudioClip level2audio;
    public AudioClip level3audio;
    public Title title;
    public AudioSource audioSource;
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        title.StartRoom1();
        audioSource.clip = level1audio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        level++;
        if (level == 2)
        {
            title.StartRoom2();
            audioSource.clip = level2audio;
        } else if (level == 3)
        {
            title.StartRoom3();
            audioSource.clip = level3audio;
        }
    }
}
