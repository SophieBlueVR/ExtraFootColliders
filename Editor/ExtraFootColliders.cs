using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using VRC.SDK3.Avatars.Components;
#endif


namespace SophieBlue.ExtraFootColliders {
    public class ExtraFootColliders : MonoBehaviour
#if HAS_IEDITOR_ONLY
, VRC.SDKBase.IEditorOnly
#endif
{

        public enum ColliderType {
            LEFT_MIDDLE     = 0,
            LEFT_RING       = 1,
            RIGHT_MIDDLE    = 2,
            RIGHT_RING      = 3,
        };

        // our source colliders, default to ring fingers
        public ColliderType ColliderLeft = ColliderType.LEFT_RING;
        public ColliderType ColliderRight = ColliderType.RIGHT_RING;

        // collider sizes
        public bool ColliderLeftSizeOverride = false;
        public float ColliderLeftRadius = 0.08f;
        public float ColliderLeftHeight = 0f;           // 0 = round
        public bool ColliderRightSizeOverride = false;
        public float ColliderRightRadius = 0.08f;
        public float ColliderRightHeight = 0f;          // 0 = round

#if UNITY_EDITOR
        public void Apply() {
            moveFingerColliders();
            DestroyImmediate(this);
        }

        private void moveFingerColliders() {
            var avDescriptor = GetComponent<VRCAvatarDescriptor>();

            // Locate the existing left foot collider
            var collider = avDescriptor.collider_footL;
            collider.state = VRCAvatarDescriptor.ColliderConfig.State.Custom;
            collider.isMirrored = false;
            if (ColliderLeftSizeOverride) {
                collider.height = ColliderLeftHeight;
                collider.radius = ColliderLeftRadius;
            }

            // overwrite the collider
            Debug.Log("Updating left foot collider");
            setCollider(avDescriptor, ColliderLeft, collider);


            // Locate the existing right foot collider
            collider = avDescriptor.collider_footR;
            collider.state = VRCAvatarDescriptor.ColliderConfig.State.Custom;
            if (ColliderRightSizeOverride) {
                collider.height = ColliderRightHeight;
                collider.radius = ColliderRightRadius;
            }

            // overwrite the collider
            Debug.Log("Updating right foot collider");
            setCollider(avDescriptor, ColliderRight, collider);
        }


        private void setCollider(VRCAvatarDescriptor avDescriptor, ColliderType which, VRCAvatarDescriptor.ColliderConfig collider) {

            switch (which) {
                case ColliderType.LEFT_RING:
                    avDescriptor.collider_fingerRingL = collider;
                    break;
                case ColliderType.LEFT_MIDDLE:
                    avDescriptor.collider_fingerMiddleL = collider;
                    break;
                case ColliderType.RIGHT_RING:
                    avDescriptor.collider_fingerRingR = collider;
                    break;
                case ColliderType.RIGHT_MIDDLE:
                    avDescriptor.collider_fingerMiddleR = collider;
                    break;
            }
        }
#endif
    }
}
