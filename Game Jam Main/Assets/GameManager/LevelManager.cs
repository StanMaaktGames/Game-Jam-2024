using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{       
    public List<GameObject> resetObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        foreach(GameObject currentObject in resetObjects)
        {
            currentObject.GetComponent<Door>()?.Load();
            currentObject.GetComponent<Button>()?.Load();
        }
    }
}
