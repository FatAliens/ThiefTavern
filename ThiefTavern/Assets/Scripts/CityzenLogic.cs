using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding {
    public class CityzenLogic : MonoBehaviour
    {
        [SerializeField]
        public GlobalWalkPoint GlobalWalkPoint;
        [SerializeField]
        public GameObject Parent;
        void Start()
        {
            GlobalWalkPoint.IsActive = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "DeadComrade")
            {
                Parent.GetComponent<NPC_Walk>().DeadComrade = other.gameObject;
                Debug.Log("" + other.tag);
                GlobalWalkPoint.AlarmPoint.transform.position = other.gameObject.transform.position;
                GlobalWalkPoint.IsActive = true;
            }
        }
    }
}
