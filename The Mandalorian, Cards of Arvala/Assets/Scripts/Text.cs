using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {
        this.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
    }
}
