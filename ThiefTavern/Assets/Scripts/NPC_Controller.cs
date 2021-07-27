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

        public bool IsFree = true; //не идет к трупу

        public GameObject DestinationPoint;

        public float CheckDeadTimer = 3f;
        public GameObject Vision;
        void Start()
        {
            ChangeDestinationPoint(RandomWalkPoint(WalkPoints, WalkPoint));
        }

        private void FixedUpdate()
        {
            if(IsFree == false)
            {
                RandomAlarmPoint(AlarmPointsLEFT, AlarmPointsRIGHT); //Должно сработать 1 раз
                ChangeDestinationPoint(AlarmPoint); //Должно сработать 1 раз
                if (CheckWalkPointDistance(DestinationPoint) == true)
                {
                    CheckingDeadComrade(CheckDeadTimer);
                }
            }
            else if(IsFree == true)
            {
                if(CheckWalkPointDistance(DestinationPoint) == true)
                {
                    ChangeDestinationPoint(RandomWalkPoint(WalkPoints, WalkPoint)); //Должно сработать 1 раз?????
                }
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

        public void RandomAlarmPoint(GameObject[] AlarmPointsLeft, GameObject[] AlarmPointsRight)
        {
            if(gameObject.GetComponent<AIPath>().desiredVelocity.x >= 0.01f)
            {
                AlarmPoint = AlarmPointsLeft[Random.Range(0, AlarmPointsLeft.Length - 1)];
            }
            else if (gameObject.GetComponent<AIPath>().desiredVelocity.x <= -0.01f)
            {
                AlarmPoint = AlarmPointsRight[Random.Range(0, AlarmPointsRight.Length - 1)];
            }
        }

        /*public GameObject RandomAlarmPoint(GameObject[] AlarmPointsLeft, GameObject[] AlarmPointsRight, GameObject AlarmPoint)
        {
            if (gameObject.GetComponent<AIPath>().desiredVelocity.x >= 0.01f)
            {
                AlarmPoint = AlarmPointsLeft[Random.Range(0, AlarmPointsLeft.Length - 1)];
            }
            else if (gameObject.GetComponent<AIPath>().desiredVelocity.x <= -0.01f)
            {
                AlarmPoint = AlarmPointsRight[Random.Range(0, AlarmPointsRight.Length - 1)];
            }
            return AlarmPoint;
        } */

        public bool CheckWalkPointDistance(GameObject Destination)
        {
            if(Mathf.Abs(gameObject.transform.position.x - Destination.transform.position.x) <= 0.2f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckingDeadComrade(float Timer)
        {
            Timer -= Time.fixedDeltaTime;
            if(Timer <= 0f)
            {
                Timer = 3f;
                Vision.GetComponent<NPCVision>().DeadComrade.tag = "CheckedDeadComrade";
                Vision.GetComponent<NPCVision>().AlarmTrigger.SetActive(false);
                IsFree = true;
            }
        }
    }
}
