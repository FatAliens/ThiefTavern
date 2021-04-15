using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class NPC_BOLVAN : MonoBehaviour
{
    public Transform[] Points;
    public float Speed = 0.0f, Distance = 0.0f;
    private int _currentPoint;
    void Start()
    { if (_currentPoint == Points.Length) _currentPoint = 0; }
    void Update()
    {
        if (_currentPoint == Points.Length) _currentPoint = 0;


        float _currentDistance = Vector2.Distance(transform.position, Points[_currentPoint].position);
        if (_currentDistance <= Distance) _currentPoint++;
        
        transform.position = Vector2.MoveTowards(transform.position, Points[_currentPoint].position, Speed * Time.deltaTime);
        
    }







}