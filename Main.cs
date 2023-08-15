using MelonLoader;
using BoneLib;
using BoneLib.BoneMenu;
using UnityEngine;
using Mono.Security.X509.Extensions;
using Boo.Lang;
using BoneLib.BoneMenu.Elements;
using SLZ.Bonelab;
using Unity.Collections;
using System;

namespace bonelab_template
{
    internal partial class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            BoneMenuCreator.InitalizeBoneMenu();
            BoneLib.Hooking.OnLevelInitialized += OnLevelLoaded;
        }

        private void OnLevelLoaded(LevelInfo info)
        {
            BoneMenuCreator.OnResetObjects();
        }
    }
}
