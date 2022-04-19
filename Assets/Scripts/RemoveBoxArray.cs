using System.Collections;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class RemoveBoxArray : MonoBehaviour
    {
        private bool _isActive = false;
        private void OnCollisionEnter(Collision collision)
        {
            if (_isActive)
                return;
            _isActive = true;
            collision.gameObject.transform.SetParent(null);
            StartCoroutine(WaitASecondForDestroy(collision.gameObject));
        }

        IEnumerator WaitASecondForDestroy(GameObject box)
        {
            yield return new WaitForSeconds(0.6f);
            if(box.tag != "dummy")
                Destroy(box);
        }
    }
}