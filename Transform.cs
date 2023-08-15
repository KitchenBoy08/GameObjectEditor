using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace bonelab_template
{
    internal class Transform
    {
        // Scale Stuff
        public static void IncreaseScale(GameObject targetObject)
        {
            Vector3 currentScale = targetObject.transform.localScale;
            Vector3 newScale = currentScale * 1.25f;
            targetObject.transform.localScale = newScale;
        }

        public static void DecreaseScale(GameObject targetObject)
        {
            Vector3 currentScale = targetObject.transform.localScale;
            Vector3 newScale = currentScale * 0.75f;
            targetObject.transform.localScale = newScale;
        }


        // Moving Stuff
        public static void MoveForward(GameObject obj, int distance)
        {
            obj.transform.Translate(Vector3.forward * distance);
        }

        public static void MoveLeft(GameObject obj, int distance)
        {
            obj.transform.Translate(Vector3.left * distance);
        }

        public static void MoveRight(GameObject obj, int distance)
        {
            obj.transform.Translate(Vector3.right * distance);
        }

        public static void MoveUp(GameObject obj, int distance)
        {
            obj.transform.Translate(Vector3.up * distance);
        }

        public static void MoveDown(GameObject obj, int distance)
        {
            obj.transform.Translate(Vector3.down * distance);
        }

        public static void MoveBack(GameObject obj, int distance)
        {
            obj.transform.Translate(Vector3.back * distance);
        }

        public static void UpTransfDist()
        {
            int currentValue = BoneMenuCreator.transformDistance;
            int changedValue = currentValue + 1;

            BoneMenuCreator.transformDistance = changedValue;
        }

        public static void DownTransfDist()
        {
            int currentValue = BoneMenuCreator.transformDistance;
            int changedValue = currentValue - 1;

            BoneMenuCreator.transformDistance = changedValue;
        }
    }
}
