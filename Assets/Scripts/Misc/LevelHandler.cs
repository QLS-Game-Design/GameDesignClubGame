using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public AudioClip level1audio;
    public AudioClip level2audio;
    public AudioClip level3audio;
    public Title title;
    public AudioSource audioSource;
    public int level = 1;
    public MoveCamera mc;
    public GameObject player;
    public Vector2 loc1;
    public Vector2 loc2;
    public Vector2 loc3;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
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
            mc.NextPos();
            player.transform.position = loc2;
        } else if (level == 3)
        {
            title.StartRoom3();
            audioSource.clip = level3audio;
            mc.NextPos();
            player.transform.position = loc3;
        } else if (level == 4)
        {
            SceneManager.LoadScene(0);
        }
    }
}
