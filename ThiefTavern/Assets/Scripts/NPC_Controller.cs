using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class NPC_Controller : MonoBehaviour
    {
        public GameObject[] WalkPoints = new GameObject[8];
        public GameObject WalkPoint;

        public GameObject AlarmTrigger;
        public GameObject[] AlarmPointsLEFT = new GameObject[3];
        public GameObject[] AlarmPointsRIGHT = new GameObject[3];
        public GameObject AlarmPoint;

        public bool IsFree = true; //не идет к трупу

        public GameObject DestinationPoint;

        public float CheckDeadTimer;
        public bool TimerStart = false;
        public bool GoingToAlarm = false;
        public GameObject Vision;

        public GameObject Graphics;
        public float RunSpeed = 2.5f;
        public float WalkSpeed = 1.7f;

        void Start()
        {
            ChangeDestinationPoint(RandomWalkPoint(WalkPoints, WalkPoint));
        }

        private void FixedUpdate()
        {
            if (IsFree == false)
            {
                if(GoingToAlarm == false)
                {
                    RandomAlarmPoint(AlarmPointsLEFT, AlarmPointsRIGHT); //Должно сработать 1 раз
                    Run();
                }

                ChangeDestinationPoint(AlarmPoint); //Должно сработать 1 раз
                if(Vision.GetComponent<NPCVision>().DeadComrade.tag == "CheckedDeadComrade")
                {
                    TimerReset();
                }
                if (CheckWalkPointDistance(DestinationPoint) == true)
                {
                    Walk();
                    CheckDeadTimer -= Time.fixedDeltaTime;
                    if (CheckDeadTimer <= 0f)
                    {
                        TimerReset();
                    }
                }
            }
            else if (IsFree == true)
            {
                if (CheckWalkPointDistance(DestinationPoint) == true)
                {
                    ChangeDestinationPoint(RandomWalkPoint(WalkPoints, WalkPoint)); //Должно сработать 1 раз?????
                    Walk();
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
            GoingToAlarm = true;
            if(gameObject.transform.position.x < AlarmTrigger.transform.position.x)
            {
                AlarmPoint = AlarmPointsLeft[Random.Range(0, AlarmPointsLeft.Length - 1)];
            }
            else if(gameObject.transform.position.x > AlarmTrigger.transform.position.x)
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

        /*public void CheckingDeadComrade(float Timer)
        {
            if(TimerStart == false)
            {
                Timer = 30f;
                TimerStart = true;
            }

            Debug.Log("" + Timer + " - " + Time.fixedDeltaTime + " = " + (Timer - Time.fixedDeltaTime));
            Timer -= Time.fixedDeltaTime;
            
            if(Timer <= 0f)
            {
                Timer = 3f;
                Vision.GetComponent<NPCVision>().DeadComrade.tag = "CheckedDeadComrade";
                Vision.GetComponent<NPCVision>().AlarmTrigger.SetActive(false);
                IsFree = true;
                GoingToAlarm = false;
                TimerStart = false;
            }
        } */

        public void Run()
        {
            Graphics.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<AIPath>().maxSpeed = RunSpeed;
        }

        public void Walk()
        {
            Graphics.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<AIPath>().maxSpeed = WalkSpeed;
        }

        public void TimerReset()
        {
            CheckDeadTimer = 3f;
            Vision.GetComponent<NPCVision>().DeadComrade.tag = "CheckedDeadComrade";
            Vision.GetComponent<NPCVision>().AlarmTrigger.SetActive(false);
            IsFree = true;
            GoingToAlarm = false;
            TimerStart = false;
            Walk();
        }

    }
}
