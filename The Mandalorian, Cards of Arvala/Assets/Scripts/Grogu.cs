using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grogu : MonoBehaviour
{
    [SerializeField] private int maxHealth = 80;
    [HideInInspector] public int health;
    public int damage = 30;
    public Jawa jawa;
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
            health -= jawa.damage;

            if (health <= 0)
            {
                Debug.Log("Grogu Died!");
                //IM TRASH

                health = 0;
            }
        }
    }
}
