using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class TriggerBox : MonoBehaviour
    {
        public static Action addBox;

        private bool _isActive = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "box")
            {
                if (!_isActive)
                {
                    _isActive = true;
                    addBox?.Invoke();
                    Destroy(gameObject);
                }
            }


        }
    }
}