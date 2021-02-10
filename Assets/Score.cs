using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int leftscore;
    public int rightscore;

    public TextMeshProUGUI leftscoretxt;
    public TextMeshProUGUI rightscoretxt;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftscoretxt.text = leftscore.ToString();
        rightscoretxt.text = rightscore.ToString();

    }

   
}
