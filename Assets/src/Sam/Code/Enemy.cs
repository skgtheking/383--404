using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] public GameObject player;

    [SerializeField] public BoxCollider2D box;

    public float movespeed, viewdistance, increase;
    private float distance;

    
    void Start()
    {
     
     player = GameObject.FindWithTag("player");
     rb = GetComponent<Rigidbody2D>();  
     box = GetComponent<BoxCollider2D>();

    }

    void FixedUpdate()
    {

        followPlayer();
        
    }

    public void followPlayer()
    {

        Vector2 enemyPosition = new Vector2(this.transform.position.x, this.transform.position.y);

        distance = Vector2.Distance(this.transform.position, player.transform.position);
        Vector2 direction = player.transform.position - this.transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        if(distance <= viewdistance)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movespeed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        
    }

    public void increaseEnemySpeed()
    {
        movespeed += increase;
        Debug.Log("Enemy Speed Increased, Current speed: " + movespeed);
        Invoke("increaseEnemySpeed", 5);
    }

    public void speedTest()
    {
        movespeed = 100;
        viewdistance = 100;
    }

}
