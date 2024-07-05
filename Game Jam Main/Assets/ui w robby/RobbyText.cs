using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbyText : MonoBehaviour
{
    public List<GameObject> lines = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(int levelInt)
    {
        foreach(GameObject currentObject in lines)
        {
            currentObject.SetActive(false);
        }
        lines[levelInt - 1].SetActive(true);
    }
}
