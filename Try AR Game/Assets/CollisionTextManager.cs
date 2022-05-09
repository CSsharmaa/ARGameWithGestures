using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTextManager : MonoBehaviour
{
    public static CollisionTextManager instance;

    public Text collisionText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void CollisionText()
    {
        for (int i = 0; i < 2; i--)
        {
            collisionText.text = "Bravo !!!";
        }


    }

   
}
