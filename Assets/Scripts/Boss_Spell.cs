using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spell : MonoBehaviour
{
    public GameObject spell;
    public Transform spellPos;
    public Animator spellanim;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spellanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        Debug.Log(timer);
        if (this.spellanim.GetCurrentAnimatorStateInfo(0).IsName("Cast"))
        {
            if(timer >= 2)
            {
                Debug.Log("Spawn");
                spellcast();
            }
        }
    }

    void spellcast()
    {
        Instantiate(spell, spellPos.position, Quaternion.identity);
    }
}

