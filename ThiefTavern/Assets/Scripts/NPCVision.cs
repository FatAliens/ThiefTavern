using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class NPCVision : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject AlarmTrigger;
        public bool InAlarmTrigger;

        public GameObject AI_Parent;

        public GameObject DeadComrade;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "DeadComrade")
            {
                AlarmTrigger.transform.position = other.gameObject.transform.position;
                AlarmTrigger.SetActive(true);
                DeadComrade = other.gameObject;
            }
        }
    }
}
