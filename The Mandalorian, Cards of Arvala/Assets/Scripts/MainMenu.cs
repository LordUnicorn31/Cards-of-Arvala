using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneChanger();
    }

    void SceneChanger()
    {
        if(Input.GetKey(KeyCode.E) /*|| touch.phase == TouchPhase.Began*/)
        {
            SceneManager.LoadScene(1);
        }
    }
}
