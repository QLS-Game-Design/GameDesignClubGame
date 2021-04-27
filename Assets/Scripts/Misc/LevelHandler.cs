using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public AudioClip level1audio;
    public AudioClip level2audio;
    public AudioClip level3audio;
    public AudioClip winaudio;
    public Title title;
    public AudioSource audioSource;
    public int level = 1;
    public MoveCamera mc;
    public GameObject player;
    public Vector2 loc1;
    public Vector2 loc2;
    public Vector2 loc3;
    public Spawner[]level1Spawners;
    public Spawner[] level2Spawners;
    public Spawner[] level3Spawners;
    bool finished = false;
    bool wavestarted = false;
    // Start is called before the first frame update
    void Start()
    {
        wavestarted = false;
        Application.targetFrameRate = 60;
        title.StartRoom1();
        audioSource.clip = level1audio;
    }

    // Update is called once per frame
    void Update()
    {
        if (title.done == true && wavestarted == false)
        {
            if (level == 1)
            {
                foreach (Spawner i in level1Spawners)
                {
                    i.NextWave();
                }
            } else if (level == 2){
                foreach (Spawner i in level2Spawners)
                {
                    i.NextWave();
                }
            } else if (level == 3){
                foreach (Spawner i in level3Spawners)
                {
                    i.NextWave();
                }
            } else if (level == 4)
            {
                SceneManager.LoadScene(0);
            }
            wavestarted = true;
        }
        if (level == 1)
        {
            finished = true;
            foreach(Spawner i in level1Spawners)
            {
                if (!i.finished)
                {
                    finished = false;
                }
            }
            if (finished == true)
            {
                LevelUp();
            }
        }
        if (level == 2)
        {
            finished = true;
            foreach (Spawner i in level2Spawners)
            {
                if (!i.finished)
                {
                    finished = false;
                }
            }
            if (finished == true)
            {
                LevelUp();
            }
        }
        if (level == 3)
        {
            finished = true;
            foreach (Spawner i in level3Spawners)
            {
                if (!i.finished)
                {
                    finished = false;
                }
            }
            if (finished == true)
            {
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        wavestarted = false;
        level++;
        if (level == 2)
        {
            title.StartRoom2();
            audioSource.clip = level2audio;
            audioSource.Play();
            mc.NextPos();
            player.transform.position = loc2;
        } else if (level == 3)
        {
            title.StartRoom3();
            audioSource.clip = level3audio;
            audioSource.Play();
            mc.NextPos();
            player.transform.position = loc3;
        } else if (level == 4)
        {
            title.Win();
            audioSource.clip = winaudio;
            audioSource.Play();

        }
    }
}
