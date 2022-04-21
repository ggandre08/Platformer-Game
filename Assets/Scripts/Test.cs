using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int vidas = 0;
        


    // Start is called before the first frame update
    void Start()
    {
        if(vidas > 0) 
        {
           Debug.Log("Player is alive");
        }
        else {
            Debug.Log("GameOver");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
