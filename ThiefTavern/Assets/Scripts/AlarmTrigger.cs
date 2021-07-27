using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding {
    public class AlarmTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Alive_NPC")
            {
                other.gameObject.GetComponent<NPCVision>().AI_Parent.GetComponent<NPC_Controller>().IsFree = false;
            }
        }
    }
}
