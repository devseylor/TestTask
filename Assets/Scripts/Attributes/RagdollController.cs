using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Attributes 
{
    public class RagdollController : MonoBehaviour
    {
        public List<Collider> RagdallParts = new List<Collider>();

        private void Start()
        {
            SetRagdollParts();
        }

        private void SetRagdollParts()
        {
            Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

            foreach (Collider collider in colliders)
            {
                if(collider.gameObject != this.gameObject)
                {
                    collider.isTrigger = true;
                    RagdallParts.Add(collider);
                }
            }
        }

        public void TurnOnRagdall()
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Animator>().enabled = false;
            GetComponent<Animator>().avatar = null;

            foreach (Collider collider in RagdallParts)
            {
                collider.isTrigger = false;
                collider.attachedRigidbody.velocity = Vector3.zero;
            }
        }
    }
}

