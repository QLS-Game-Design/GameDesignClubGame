using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public string level;
    public string story;
    public Text msg;
    // Start is called before the first frame update
    void Start()
    {
        msg.text = level;
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        msg.text = story;
        yield return new WaitForSeconds(8);
        this.gameObject.SetActive(false);
    }
}
