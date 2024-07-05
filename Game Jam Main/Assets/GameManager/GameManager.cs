using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> levels = new List<GameObject>();
    public List<Vector2> spawnPosition = new List<Vector2>();

    int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel(level);
        }
    }

    public void LoadLevel(int levelInt)
    {
        foreach (GameObject unloadLevel in levels)
        {
            unloadLevel.SetActive(false);
        }
        levels[levelInt - 1].SetActive(true);
        levels[levelInt - 1].GetComponent<LevelManager>().Load();
        
        Debug.Log("load");
        player.GetComponent<PlayerController>().Spawn(spawnPosition[levelInt - 1].x, spawnPosition[levelInt - 1].y);
    }

    public void Finish()
    {
        level += 1;
        LoadLevel(level);
    }
}
