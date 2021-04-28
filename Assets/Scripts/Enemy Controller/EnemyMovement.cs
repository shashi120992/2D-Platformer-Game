using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy_Controller
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveForce = 0f;
        private Rigidbody2D rb2d;
        public Vector3 moveDir;
        public LayerMask whatsWall;
        public float maxDistFromWall;

     
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            moveDir = ChooseDirection();
        }

        // Update is called once per frame
        void Update()
        {
            rb2d.velocity = moveDir * moveForce;
        }

        Vector3 ChooseDirection()
        {
            System.Random ran = new System.Random();
            int i = ran.Next(0, 1);
            Vector3 temp = new Vector3();

            if(i == 0)
            {
                temp = transform.forward;
            }
            else if (i == 1)
            {
                temp = -transform.forward;
            }
            return temp;
        }

    }
}