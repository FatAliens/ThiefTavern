using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameGenerator : MonoBehaviour
{
    private bool isGenerate;
    [SerializeField] private float GenerateTime;
    [SerializeField] private GameObject GeneratedObject;

    [SerializeField] private float HorMaxPosition;
    [SerializeField] private float HorMinPosition;
    [SerializeField] private float MovePerSecond;
    [SerializeField] private float RandomMoveTime;
    private bool derection = true;

    private void Start()
    {
        StartCoroutine("CalcDerection");
        StartCoroutine("GenerateObjects");
    }
    private IEnumerator GenerateObjects()
    {
        while(true)
        {
            yield return new WaitForSeconds(GenerateTime);
            Instantiate(GeneratedObject, transform.position, Quaternion.identity);
        }
    }
    private IEnumerator CalcDerection()
    {
        while (true)
        {
            yield return new WaitForSeconds(RandomMoveTime);
            derection = Random.Range(0, 2) == 1 ? true : false;
        }
    }
    private void FixedUpdate()
    {
        if (derection)
        {
            if (transform.position.y >= HorMaxPosition)
            {
                derection = !derection;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + MovePerSecond, 0);
            }
        }
        else
        {
            if (transform.position.y <= HorMinPosition)
            {
                derection = !derection;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - MovePerSecond, 0);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(transform.position.x, HorMaxPosition, 0), new Vector3(transform.position.x, HorMinPosition, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + (derection ? 1 : -1), 0));
    }
}
