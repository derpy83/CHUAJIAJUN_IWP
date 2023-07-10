using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdropper : MonoBehaviour
{
    public GameObject itemdrop;
    public Transform dropperPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHP.Instance.Healthbar.value <= 0)
        {
            DropItem();
            Destroy(this);
        }
    }
    public void DropItem()
    {
        Instantiate(itemdrop, dropperPos.position + new Vector3(1.5f, 1, 0), Quaternion.identity);
    }
}
