using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void UpdateScore()
    {
        score += 1;
        // TODO : update screen 
    }
    
    public void UpdateLive()
    {
        lives -= 1;
        // TODO : update screen 
    }
}
