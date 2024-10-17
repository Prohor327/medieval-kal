using System.Collections.Generic;
using UnityEngine;

namespace SkeletonEditor
{

    public class PlayerController : MonoBehaviour
    {
        public float mouseRotateSpeed = 0.3f;

        private Animator animator;
        private Quaternion initRotation;

        void Start() {
            animator = GetComponent<Animator>();
            initRotation = transform.rotation;
        }
    }
}