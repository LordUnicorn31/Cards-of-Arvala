using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGrogu : MonoBehaviour
{
    public GameObject obj;
    private TextMesh text;
    public Grogu grogu;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        text.text = $"Life: {grogu.health.ToString()}";
    }
}
