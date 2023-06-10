using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item_Drop : MonoBehaviour
{

    public float amp;
    Vector3 initpos;

    // Start is called before the first frame update
    void Start()
    {
       
        initpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, Mathf.Sin(Time.time) * amp + initpos.y, 0);
    }
   
    
    
}
