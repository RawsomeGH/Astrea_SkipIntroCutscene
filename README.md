# Astrea_SkipIntroCutscene
Small proof of concept BepInEx 6 patch for Astrea: Six-Sided Oracles.

You can use this a template to get started with modding the game, although I recommend reading the documentation for all the tools you're going to use.

## Important tools

### [BepInEx](https://docs.bepinex.dev/master/articles/user_guide/installation/unity_il2cpp.html)

Make sure the documentation you read is for BepInEx 6, which is *not* a stable version yet, but has extensive support for modding IL2CPP games.

In addition to a general explanation, the Plugin development guide also shows how you can use the nice project templates (the correct one for this game is, at the moment, `bep6plugin_unity_il2cpp`).

In the sections providing instructions depending on game type, make sure "`Unity (Il2Cpp)`" is selected.

### [HarmonyX](https://github.com/BepInEx/HarmonyX/wiki)

Used for writing patches. To learn the basics, visit the [official Harmony 2 docs](https://harmony.pardeike.net/articles/intro.html).

### Something to analyze the game code

After installing BepInEx and running the game for the first time afterwards, you will have access to Assembly-Csharp.dll (it will be put in `<Game_Folder>/BepInEx/interop`). There are several applications you can use to find the methods you want to patch.

Some examples :
- dnSpy
- dotPeek
- ILSpy

## Building this mod

Before you can build this mod locally, you need to add some required DLLs to the project's `lib` folder. Refer to [LibsToPutHere.txt in the lib folder](/src/Astrea_SkipIntroCutscene/lib/LibsToPutHere.txt).

After a successful build, you only need to copy `at.rawsome.Astrea.SkipIntroCutscene.dll` out of the `bin` folder into BepInEx's `plugins` folder.
