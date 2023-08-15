using BoneLib.BoneMenu.Elements;
using JetBrains.Annotations;
using SLZ.Rig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace bonelab_template
{
    public static class BoneMenuCreator
    {
        public static int transformDistance = 5;
        public static BoneLib.BoneMenu.Elements.MenuCategory category;
        public static List<MenuCategory> menuCategories = new List<MenuCategory>();

        public static void InitalizeBoneMenu()
        {
            category = BoneLib.BoneMenu.MenuManager.CreateCategory("GameObject Editor", Color.green);
            OnResetObjects();
        }

        public static void CreateBoneMenu()
        {
            GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject obj in gameObjects)
            {
                int instanceId = obj.GetInstanceID();
                MenuCategory gameObjectCategory = category.CreateCategory(obj.name, Color.white);

                gameObjectCategory.CreateSubPanel($"{obj.name} InstanceID: {instanceId}", Color.white);

                gameObjectCategory.CreateSubPanel($"Current position: {obj.transform.position}", Color.cyan);

                // Activation stuff
                gameObjectCategory.CreateFunctionElement("Activate Game Object", Color.white, () => obj.SetActive(true));
                gameObjectCategory.CreateFunctionElement("Deactivate Game Object", Color.white, () => obj.SetActive(false));

                // Create Transform Stuffs
                var transformStuff = gameObjectCategory.CreateCategory("Transform Stuff", Color.blue);

                /// Scale stuff
                var scaleCategory = transformStuff.CreateCategory("Scale Stuff", Color.white);
                scaleCategory.CreateFunctionElement("Increase size by 25%", Color.white, () => Transform.IncreaseScale(obj));
                scaleCategory.CreateFunctionElement("Decrease size by 25%", Color.white, () => Transform.DecreaseScale(obj));

                /// Moving stuff
                var moveCategory = transformStuff.CreateCategory("Moving Stuff", Color.white);

                moveCategory.CreateFunctionElement("Raise Transform Distance", Color.white, () => Transform.UpTransfDist());
                moveCategory.CreateFunctionElement("Raise Transform Distance", Color.white, () => Transform.DownTransfDist());

                moveCategory.CreateFunctionElement($"Move forward", Color.white, () => Transform.MoveForward(obj, transformDistance));
                moveCategory.CreateFunctionElement($"Move back", Color.white, () => Transform.MoveBack(obj, transformDistance));
                moveCategory.CreateFunctionElement($"Move left", Color.white, () => Transform.MoveLeft(obj, transformDistance));
                moveCategory.CreateFunctionElement($"Move right", Color.white, () => Transform.MoveRight(obj, transformDistance));
                moveCategory.CreateFunctionElement($"Move up", Color.white, () => Transform.MoveUp(obj, transformDistance));
                moveCategory.CreateFunctionElement($"Move down", Color.white, () => Transform.MoveDown(obj, transformDistance));
            }
        }

        public static void OnResetObjects()
        {
            category.Elements.Clear();

            var sub = category.CreateSubPanel("Refresh Objects", Color.red);
            sub.CreateFunctionElement("WARNING, THIS TAKES A WHILE", Color.yellow, null);
            sub.CreateFunctionElement("Upwards of 10 minutes!", Color.yellow, null);
            sub.CreateFunctionElement("(On large maps)", Color.yellow, null);
            sub.CreateFunctionElement("But it only needs to be done once...", Color.yellow, null);
            sub.CreateFunctionElement("Are you sure you want to do this?", Color.yellow, null);
            sub.CreateFunctionElement("Yes, Refresh!", Color.red, () => OnResetObjects());

            CreateBoneMenu();
        }
    }
}
