using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour

    
{

    // coin goes to index 1, treasure chest goes to index 2, diamond goes to index 3
    

    public Treasure[] collectibles = new Treasure[3];
    public int[] count = new int[3];



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
