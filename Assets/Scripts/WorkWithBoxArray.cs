using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorkWithBoxArray : MonoBehaviour
    {
        public static Action activeGameOver;

        [SerializeField] private GameObject _box;

        [SerializeField] private List<GameObject> _arrayBox = new List<GameObject>();

        private void Update()
        {
            RemoveBox();
        }
        public void SpawnBox()
        {
            var newBox = Instantiate(_box, new Vector3(0, -0.5f), Quaternion.identity);
            newBox.transform.SetParent(gameObject.transform);
            _arrayBox.Add(newBox);

            CorrectVerticalPosition();
           
        }
        private void RemoveBox()
        {
            for(int i = 0; i < _arrayBox.Count; i++)
            {
                if (_arrayBox[i] == null)
                    _arrayBox.Remove(_arrayBox[i].gameObject);
            }
            if (_arrayBox.Count <= 1)
                activeGameOver?.Invoke();
        }

        private void CorrectVerticalPosition()
        {
            for(int i = 0; i < _arrayBox.Count; i++)
            {
                _arrayBox[i].transform.localPosition = new Vector3(0, _arrayBox[i].transform.position.y + 1, 0);
            }
        }


    }
}