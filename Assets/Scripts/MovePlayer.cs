using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts 
{
    public class MovePlayer : MonoBehaviour
    {
        private int speed = 3;

        private Vector3 _startTouchPos = new Vector3(500, 0);


        private void FixedUpdate()
        {
            Move();
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        private void Move()
        {
            transform.position = transform.position + Vector3.forward * speed * Time.fixedDeltaTime;

            if (Input.GetMouseButton(0))
            {

                if(_startTouchPos.x < Input.mousePosition.x)
                {
                    MoveLeftOrRight(Vector3.right);
                }
                else if(_startTouchPos.x > Input.mousePosition.x)
                {
                    MoveLeftOrRight(Vector3.left);
                }
            }
        }

        private void MoveLeftOrRight(Vector3 moveDir)
        {
            transform.position = transform.position + moveDir * speed * Time.fixedDeltaTime;
        }

    }
}

