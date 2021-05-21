using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jawa : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [HideInInspector] public int health;
    [SerializeField] private int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            health -= damage;

            if (health <= 0)
            {
                Debug.Log("Jawa Died!");
            }
        }
    }
}
