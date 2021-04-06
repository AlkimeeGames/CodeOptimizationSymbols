# Code Optimization Symbols

[![OpenUPM](https://img.shields.io/npm/v/com.alkimeegames.codeoptimizationsymbols?label=OpenUPM&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.alkimeegames.codeoptimizationsymbols/)
[![GitHub Release Date](https://img.shields.io/github/release-date/AlkimeeGames/CodeOptimizationSymbols)](https://github.com/AlkimeeGames/CodeOptimizationSymbols/releases)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-green.svg)](http://makeapullrequest.com)
[![Unity 2018.4 or Layer](https://img.shields.io/badge/unity-2020.1%20or%20later-green.svg)](https://unity3d.com/unity/qa/lts-releases)
[![MIT License](https://img.shields.io/github/license/AlkimeeGames/CodeOptimizationSymbols)](https://github.com/AlkimeeGames/CodeOptimizationSymbols/blob/main/LICENSE.md)
[![](https://img.shields.io/badge/Keep%20a%20Changelog-v1.0.0-green.svg?logo=data%3Aimage%2Fsvg%2Bxml%3Bbase64%2CPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIGZpbGw9IiNmMTVkMzAiIHZpZXdCb3g9IjAgMCAxODcgMTg1Ij48cGF0aCBkPSJNNjIgN2MtMTUgMy0yOCAxMC0zNyAyMmExMjIgMTIyIDAgMDAtMTggOTEgNzQgNzQgMCAwMDE2IDM4YzYgOSAxNCAxNSAyNCAxOGE4OSA4OSAwIDAwMjQgNCA0NSA0NSAwIDAwNiAwbDMtMSAxMy0xYTE1OCAxNTggMCAwMDU1LTE3IDYzIDYzIDAgMDAzNS01MiAzNCAzNCAwIDAwLTEtNWMtMy0xOC05LTMzLTE5LTQ3LTEyLTE3LTI0LTI4LTM4LTM3QTg1IDg1IDAgMDA2MiA3em0zMCA4YzIwIDQgMzggMTQgNTMgMzEgMTcgMTggMjYgMzcgMjkgNTh2MTJjLTMgMTctMTMgMzAtMjggMzhhMTU1IDE1NSAwIDAxLTUzIDE2bC0xMyAyaC0xYTUxIDUxIDAgMDEtMTItMWwtMTctMmMtMTMtNC0yMy0xMi0yOS0yNy01LTEyLTgtMjQtOC0zOWExMzMgMTMzIDAgMDE4LTUwYzUtMTMgMTEtMjYgMjYtMzMgMTQtNyAyOS05IDQ1LTV6TTQwIDQ1YTk0IDk0IDAgMDAtMTcgNTQgNzUgNzUgMCAwMDYgMzJjOCAxOSAyMiAzMSA0MiAzMiAyMSAyIDQxLTIgNjAtMTRhNjAgNjAgMCAwMDIxLTE5IDUzIDUzIDAgMDA5LTI5YzAtMTYtOC0zMy0yMy01MWE0NyA0NyAwIDAwLTUtNWMtMjMtMjAtNDUtMjYtNjctMTgtMTIgNC0yMCA5LTI2IDE4em0xMDggNzZhNTAgNTAgMCAwMS0yMSAyMmMtMTcgOS0zMiAxMy00OCAxMy0xMSAwLTIxLTMtMzAtOS01LTMtOS05LTEzLTE2YTgxIDgxIDAgMDEtNi0zMiA5NCA5NCAwIDAxOC0zNSA5MCA5MCAwIDAxNi0xMmwxLTJjNS05IDEzLTEzIDIzLTE2IDE2LTUgMzItMyA1MCA5IDEzIDggMjMgMjAgMzAgMzYgNyAxNSA3IDI5IDAgNDJ6bS00My03M2MtMTctOC0zMy02LTQ2IDUtMTAgOC0xNiAyMC0xOSAzN2E1NCA1NCAwIDAwNSAzNGM3IDE1IDIwIDIzIDM3IDIyIDIyLTEgMzgtOSA0OC0yNGE0MSA0MSAwIDAwOC0yNCA0MyA0MyAwIDAwLTEtMTJjLTYtMTgtMTYtMzEtMzItMzh6bS0yMyA5MWgtMWMtNyAwLTE0LTItMjEtN2EyNyAyNyAwIDAxLTEwLTEzIDU3IDU3IDAgMDEtNC0yMCA2MyA2MyAwIDAxNi0yNWM1LTEyIDEyLTE5IDI0LTIxIDktMyAxOC0yIDI3IDIgMTQgNiAyMyAxOCAyNyAzM3MtMiAzMS0xNiA0MGMtMTEgOC0yMSAxMS0zMiAxMXptMS0zNHYxNGgtOFY2OGg4djI4bDEwLTEwaDExbC0xNCAxNSAxNyAxOEg5NnoiLz48L3N2Zz4K)](https://github.com/AlkimeeGames/CodeOptimizationSymbols/blob/develop/CHANGELOG.md)
[![GitHub Org's Stars](https://img.shields.io/github/stars/alkimeegames?style=social)](https://github.com/AlkimeeGames)

> **Automatically** sets preprocessor directives based on the Code Optimization mode set in the Unity Editor.

## What are Code Optimization Symbols?

The Code Optimization Symbols tool automatically creates [Compiler Symbols](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html) based on the Unity
Editor's [Code Optimization](https://docs.unity3d.com/Manual/ManagedCodeDebugging.html) mode. These compiler symbols can then be used in your code to change behaviour based on the
currently active Code Optimization mode.

## Why use the Code Optimization Symbols?

Having compiler symbols for both the Debug and Release Code Optimization modes allows you to write code that is only available when either of these modes are available.

For example, you may have a class which writes logs to the Unity Console when actions occur. You could use the pre-existing 'UNITY_EDITOR' symbol which would result in logs being sent to
the console whenever you're running the game in the Editor. However, if you don't need these logs all the time and only need them whilst debugging, surrounding the code with the
'UNITY_EDITOR_DEBUG' symbol will make those logs *only* appear when the Editor is in Debug Code Optimization mode.

Naturally, the symbols set by this tool can be used for more than just logging. You could also instantiate entirely difference classes based on the Code Optimization mode for
performance reasons.

## Whats wrong with #if UNITY_EDITOR et al?

The [Platform Dependant Compilation](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html) symbols already provided by the Unity Editor are excellent for targeting
specific platforms or code you only want to run in the Editor. However, it provides no means for determining which Code Optimization mode the Unity Editor is currently in. This
means you currently cannot have code run in the Editor when only in the Debug Code Optimization mode.

## Setup

The Code Optimization Symbols tool works out of the box, automatically and in the background with no dependencies other than Unity itself. It's pure CSharp and the public API has
complete XML documentation.

## How does this work?

The Code Optimization Symbols tool adds two new compiler symbols determined by which Code Optimization mode the Editor is in. Because of this, they can never both be set at the same
time.

- Debug Mode introduces the "UNITY_EDITOR_DEBUG" symbol.
- Release Mode introduces the "UNITY_EDITOR_RELEASE" symbol.

## Automatic Behaviour

- When building your project the symbols will be automatically removed and re-added once the build is complete.
- Switching platforms via the [Build Settings](https://docs.unity3d.com/Manual/BuildSettings.html) window or via script will automatically remove the symbols from the previous platform
  and add them to the now active platform.
- Exiting the Editor will remove either of the symbols.

## Example Usages

### As a [preprocessor directive](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives)

```c#
public sealed class Bullet : MonoBehaviour
{
    private void OnCollisionEnter([Collision other)
    {
        if (other.gameObject.CompareTag("Player")) {

#if UNITY_EDITOR_DEBUG
            // You will only see this log in the Editor AND if the Editor is in Debug Code Optimization mode.
            Debug.Log("Destroying " + other.name);
#endif

            Destroy(other.gameObject);
        }
    }
 }
```

### Using the [Conditional Attribute](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.conditionalattribute?view=netstandard-2.0)

```c#
using System.Diagnostics;
using static AlkimeeGames.CodeOptimizationSymbols.Symbol;

public sealed class PlayerState
{
    private void PerformingAction()
    {
        Log("I performed an action.");
    }

    [Conditional(CodeOptimizationDebug)]
    private void Log(string @string)
    {
        Debug.Log(@string)
    }
}
```

Using the Conditional Attribute with [Code Stripping](https://docs.unity3d.com/2020.1/Documentation/Manual/ManagedCodeStripping.html) disabled or set to Low will result in the call
site to the method being removed from the build. With Code Stripping set to Medium or High, the call site *and* the method definition will be removed from the build (except in the
case of classes deriving from MonoBehaviour or ScriptableObject where Unity tends to be more pessimistic in stripping code from those derived classes).

## API and Extensibility

There are two public events available to subscribe to from your own Editor scripts.

- CodeOptimizationSymbols.SettingSymbols
    - Raised *before* setting the symbols.
- CodeOptimizationSymbols.SetSymbols
    - Raised *after* setting the symbols.

Both pass an ISet<string> to the subscribed method which contains *all* the symbols being applied.

You can also access the names of the symbols directly in your code.

- Symbol.CodeOptimizationDebug
- Symbol.CodeOptimizationRelease

## Installation

### Install via OpenUPM

The package is available on the [openupm registry](https://openupm.com/packages/com.alkimeegames.codeoptimizationsymbols/). It's recommended to install it
via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.alkimeegames.codeoptimizationsymbols
```

### Install Via Package Manager

Via the Package Manager, you can add the package as a Git dependency. Follow the instructions for
[Installing froma Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html) and further information around
[Git dependencies](https://docs.unity3d.com/Manual/upm-git.html) in Unity. We advise specifically locking to the
[main](https://github.com/AlkimeeGames/CodeOptimizationSymbols/tree/main) branch.

### Install Via Manifest.json

Open *Packages/manifest.json* with your favorite text editor. Add the following line to the dependencies block.

    {
        "dependencies": {
            "com.alkimeegames.codeoptimizationsymbols": "https://github.com/AlkimeeGames/CodeOptimizationsymbols.git#main"
        }
    }

#### Git Updates

The Unity Package Manager records the current commit to a lock entry of the *manifest.json*. To update to the latest version, change the hash value manually or remove the lock
entry to re-resolve the package.

    "lock": {
      "com.alkimeegames.codeoptimizationsymbols": {
        "revision": "main",
        "hash": "..."
      }
    }
