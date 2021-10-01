using System;
using UnityEngine;

namespace Script
{
    public class ArrowScript : MonoBehaviour
    {
        // Start is called before the first frame update
        private MeshRenderer _meshRenderer;

        void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Math.Abs(Input.GetAxis("Shot_h")) < 0.1f && Math.Abs(Input.GetAxis("Shot_v")) < 0.1f)
            {
                _meshRenderer.enabled = false;
                return;
            }

            _meshRenderer.enabled = true;
            float angle = Mathf.Atan2(Input.GetAxis("Shot_h"), Input.GetAxis("Shot_v")) * Mathf.Rad2Deg + 90;
            var rot = Quaternion.Euler(0, angle, 0);
            transform.rotation = rot;
        }
    }
}