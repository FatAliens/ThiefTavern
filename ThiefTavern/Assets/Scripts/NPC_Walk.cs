using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
    public class NPC_Walk : MonoBehaviour
    {
        [SerializeField]
        public GameObject[] WalkPoints = new GameObject[4];
        [SerializeField]
        private GameObject WalkPoint;
        [SerializeField]
        public GlobalWalkPoint GlobalWalkPoint;
        [SerializeField]
        public GameObject SoundSource;
        [SerializeField]
        public bool IsDead = false;
        [SerializeField]
        public bool SoundWalk = false;
        [SerializeField]
        public float Timer = 3.5f;
        [SerializeField]
        public GameObject DeadComrade;
        [SerializeField]
        public bool WentToCheck = false;

        private void Start()
        {
            WalkPoint = WalkPoints[Random.Range(0, 4)];
            gameObject.GetComponent<AIDestinationSetter>().target = WalkPoint.GetComponent<Transform>();
        }
        private void FixedUpdate()
        {
            if (GlobalWalkPoint.IsActive == false && WentToCheck == true)
            {
                WalkPoint = WalkPoints[Random.Range(0, 4)];
                gameObject.GetComponent<AIDestinationSetter>().target = WalkPoint.GetComponent<Transform>();
                WentToCheck = false;
            }
            if (GlobalWalkPoint.IsActive == false /*&& SoundWalk == false*/)
            {
                if (Mathf.Abs(gameObject.transform.position.x - WalkPoint.transform.position.x) <= 0.2f)
                {
                    WalkPoint = WalkPoints[Random.Range(0, 4)];
                    gameObject.GetComponent<AIDestinationSetter>().target = WalkPoint.GetComponent<Transform>();
                }
            }
            else if(GlobalWalkPoint.IsActive == true)
            {
                WentToCheck = GlobalWalkPoint.IsActive;
                gameObject.GetComponent<AIDestinationSetter>().target = GlobalWalkPoint.AlarmPoint.GetComponent<Transform>();
                if(Mathf.Abs(gameObject.transform.position.x - GlobalWalkPoint.AlarmPoint.transform.position.x) <= 0.2f)
                {
                    Timer -= Time.fixedDeltaTime;
                    if (Timer <= 0f)
                    {
                        Timer = 3.5f;
                        DeadComrade.tag = "CheckedDeadComrade";
                        GlobalWalkPoint.IsActive = false;
                        WalkPoint = WalkPoints[Random.Range(0, 4)];
                        gameObject.GetComponent<AIDestinationSetter>().target = WalkPoint.GetComponent<Transform>();
                    }
                }
            }
        }
        public void HeardSound()
        {
            gameObject.GetComponent<AIDestinationSetter>().target = SoundSource.GetComponent<Transform>();
            SoundWalk = true;
        }
        public void Dead()
        {
            gameObject.GetComponent<AIPath>().enabled = false;
            gameObject.GetComponent<AIDestinationSetter>().enabled = false;
            gameObject.tag = "DeadComrade";
        }

    }
}
