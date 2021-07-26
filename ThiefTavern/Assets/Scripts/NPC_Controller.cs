using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class NPC_Controller : MonoBehaviour
    {
        public GameObject[] WalkPoints = new GameObject[8];
        public GameObject WalkPoint;

        public GameObject[] AlarmPointsLEFT = new GameObject[3];
        public GameObject[] AlarmPointsRIGHT = new GameObject[3];
        public GameObject AlarmPoint;

        public bool IsFree; //не идет к трупу

        public bool ReachedPoint;
        public GameObject DestinationPoint;
        void Start()
        {
            ChangeDestinationPoint(RandomWalkPoint(WalkPoints, WalkPoint));
        }

        private void FixedUpdate()
        {
            if(IsFree == false)
            {
                ChangeDestinationPoint(RandomAlarmPoint(AlarmPointsLEFT, AlarmPointsRIGHT, AlarmPoint));
            }
            else
            {
                
            }
        }
        public void ChangeDestinationPoint(GameObject Point)
        {
            gameObject.GetComponent<AIDestinationSetter>().target = Point.GetComponent<Transform>();
            DestinationPoint = Point;
        }

        public GameObject RandomWalkPoint(GameObject[] WalkPoints, GameObject WalkPoint)
        {
                WalkPoint = WalkPoints[Random.Range(0, WalkPoints.Length-1)];
                return WalkPoint;
        }

        public GameObject RandomAlarmPoint(GameObject[] AlarmPointsLeft, GameObject[] AlarmPointsRight, GameObject AlarmPoint)
        {
            if(gameObject.GetComponent<AIPath>().desiredVelocity.x >= 0.01f)
            {
                AlarmPoint = AlarmPointsLeft[Random.Range(0, AlarmPointsLeft.Length - 1)];
            }
            else if (gameObject.GetComponent<AIPath>().desiredVelocity.x <= -0.01f)
            {
                AlarmPoint = AlarmPointsRight[Random.Range(0, AlarmPointsRight.Length - 1)];
            }
            return AlarmPoint;
        }

        public bool CheckWalkPointDistance(bool Reached, GameObject Destination)
        {
            if(Mathf.Abs(gameObject.transform.position.x - Destination.transform.position.x) <= 0.1f)
            {
                Reached = true;
            }
            else
            {
                Reached = false;
            }
            return Reached;
        }
    }
}
