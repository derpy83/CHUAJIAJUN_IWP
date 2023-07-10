using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject BossSpawner1;
    public GameObject BossSpawner2;
    public GameObject BossSpawner3;

    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boss1.SetActive(true);
        }
    }
}
