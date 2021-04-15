using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float LiveTime;
    [SerializeField] private Vector2 MoveVector;
    [SerializeField] private ParticleSystem triggerParticle;
    private float timer;

    private void Start()
    {
        timer = LiveTime;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + Speed * MoveVector.x, transform.position.y + Speed * MoveVector.y, 0);
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //triggerParticle.Play();
            Destroy(this.gameObject);
        }
    }
}
