#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;
using VRC.SDKBase.Editor.BuildPipeline;

namespace SophieBlue.ExtraFootColliders {
    [InitializeOnLoad]
    public class AvatarBuildHook : IVRCSDKPreprocessAvatarCallback {

        public int callbackOrder => -1025;

        public bool OnPreprocessAvatar(GameObject avatarGameObject) {
            var mover = avatarGameObject.GetComponent<ExtraFootColliders>();

            if (mover == null) {
                return true;
            }

            try {
                mover.Apply();
                return true;
            }
            catch (Exception e) {
                Debug.LogError(e);
                return false;
            }
        }
    }
}
#endif
