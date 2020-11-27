using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class randomizeText : MonoBehaviour
{
    [TextArea(3,10)]
    public string[] quotes;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        int i = Random.Range(0, quotes.Length);
        text.text = quotes[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
