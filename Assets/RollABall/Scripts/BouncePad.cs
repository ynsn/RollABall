using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamNameHere
{
    public class BouncePad : MonoBehaviour
    {
        private MeshRenderer renderer;

        private Color defaultColor;
        [SerializeField] private Color touchColor;

        private void Start()
        {
            renderer = GetComponent<MeshRenderer>();
            defaultColor = renderer.material.color;
        }

        private void OnCollisionEnter(Collision other)
        {
            renderer.material.color = touchColor;
        }

        private void OnCollisionExit(Collision other)
        {
            renderer.material.color = defaultColor;
        }
    }
}