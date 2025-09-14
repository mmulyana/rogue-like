using System.Collections.Generic;
using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool CloseWhenEntered, openWhenEnemiesCleared;

    public GameObject[] doors;

    public List<GameObject> enemies = new List<GameObject>();

    private bool roomActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count > 0 && roomActive && openWhenEnemiesCleared)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }

            if(enemies.Count == 0)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(false);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Console.Write("Masuk room");
            CameraController.instance.ChangeTarget(transform);

            if(CloseWhenEntered)
            {
                foreach (GameObject door in doors)
                {
                    door.SetActive(true);
                }
            }

            roomActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            roomActive = false;
        }
    }
}
