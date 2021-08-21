using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamerTag : MonoBehaviour
{
    [SerializeField]
    Text GamerTagText;
    InputField gamertag;
    float secondsSinceLastOutput=0;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
        gamertag = GamerTagText.GetComponent<InputField>(); 
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastOutput += Time.deltaTime;
        if (secondsSinceLastOutput > 1)
        {
            secondsSinceLastOutput = 0;
            print(gamertag.text);
        }
    }
}
