using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Compilation;
using UnityEngine.Events;

namespace AlkimeeGames.CodeOptimizationSymbols.Editor
{
    /// <summary>Automatically sets preprocessor directives based on the <see cref="CompilationPipeline.codeOptimization" /> set in the Unity Editor.</summary>
    [PublicAPI]
    public sealed class SymbolSetter : IPreprocessBuildWithReport, IPostprocessBuildWithReport, IActiveBuildTargetChanged
    {
        /// <summary>Symbol for the <see cref="BuildTargetGroup" />.</summary>
        private static readonly ISet<string> Symbols = new HashSet<string>();

        /// <summary>Gets the current <see cref="BuildTarget" />.</summary>
        private static BuildTarget ActiveBuildTarget => EditorUserBuildSettings.activeBuildTarget;

        /// <inheritdoc />
        public void OnActiveBuildTargetChanged(BuildTarget previousTarget, BuildTarget newTarget)
        {
            ChangeSymbols(RemoveCompilationCodeOptimizationSymbols, previousTarget);
            ChangeSymbols(AddCompilationCodeOptimizationSymbols, newTarget);
        }

        /// <inheritdoc />
        public void OnPostprocessBuild([NotNull] BuildReport buildReport)
        {
            ChangeSymbols(AddCompilationCodeOptimizationSymbols, buildReport.summary.platform);
        }

        /// <inheritdoc />
        public int callbackOrder => int.MinValue;

        /// <inheritdoc />
        public void OnPreprocessBuild([NotNull] BuildReport buildReport)
        {
            ChangeSymbols(RemoveCompilationCodeOptimizationSymbols, buildReport.summary.platform);
        }

        /// <summary>Raised <b>prior</b> to setting symbols.</summary>
        [PublicAPI] public static event UnityAction<ISet<string>> SettingSymbols;

        /// <summary>Raised <b>after</b> to setting symbols.</summary>
        [PublicAPI] public static event UnityAction<ISet<string>> SetSymbols;

        /// <summary>Method to be initialized when Unity loads.</summary>
        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            ChangeSymbols(AddCompilationCodeOptimizationSymbols, ActiveBuildTarget);
            EditorApplication.wantsToQuit += WantsToQuit;
        }

        /// <summary>Changes the symbols for a build target.</summary>
        /// <param name="perform">Which action to perform against the symbol set.</param>
        /// <param name="buildTarget">Which build target to apply the symbol changes to.</param>
        private static void ChangeSymbols([NotNull] Action<ISet<string>> perform, BuildTarget buildTarget)
        {
            BuildTargetGroup buildTargetGroup = GetBuildTargetGroup(buildTarget);
            Symbols.Clear();

            GetBuildTargetGroupSymbols(buildTargetGroup, Symbols);

            perform(Symbols);
            SettingSymbols?.Invoke(Symbols);

            SetBuildTargetGroupSymbols(buildTargetGroup, Symbols);
            SetSymbols?.Invoke(Symbols);
        }

        /// <summary>Returns a <see cref="BuildTargetGroup" /> for a given <see cref="BuildTarget" />.</summary>
        /// <param name="buildTarget">Which <see cref="BuildTarget" /> to get the <see cref="BuildTargetGroup" /> for.</param>
        /// <returns>The <see cref="BuildTargetGroup" /> for the given <see cref="BuildTarget" />.</returns>
        private static BuildTargetGroup GetBuildTargetGroup(BuildTarget buildTarget) => BuildPipeline.GetBuildTargetGroup(buildTarget);

        /// <summary>Unity raises this event when the editor application wants to quit.</summary>
        /// <returns>Always <see langword="true" />.</returns>
        private static bool WantsToQuit()
        {
            ChangeSymbols(RemoveCompilationCodeOptimizationSymbols, ActiveBuildTarget);
            EditorApplication.wantsToQuit -= WantsToQuit;
            return true;
        }

        /// <summary>Sets the symbols for a <see cref="BuildTargetGroup" />.</summary>
        /// <param name="buildTargetGroup">Which <see cref="BuildTargetGroup" /> to add <paramref name="symbols" /> to.</param>
        /// <param name="symbols">An <see cref="IEnumerable{T}" /> of symbols to add.</param>
        private static void SetBuildTargetGroupSymbols(BuildTargetGroup buildTargetGroup, [NotNull] IEnumerable<string> symbols)
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, symbols.ToArray());
        }

        /// <summary>Populates <paramref name="symbolSet" /> with a symbol based on the current <see cref="CodeOptimization" />.</summary>
        /// <param name="symbolSet">A set to populate with the <see cref="CodeOptimization" /> symbol.</param>
        private static void AddCompilationCodeOptimizationSymbols([NotNull] ISet<string> symbolSet)
        {
            RemoveCompilationCodeOptimizationSymbols(Symbols);

            if (CompilationPipeline.codeOptimization == CodeOptimization.Debug)
                symbolSet.Add(Symbol.CodeOptimizationDebug);
            if (CompilationPipeline.codeOptimization == CodeOptimization.Release)
                symbolSet.Add(Symbol.CodeOptimizationRelease);
        }

        /// <summary>Removes <see cref="CodeOptimization" /> symbols from <paramref name="symbolSet" />.</summary>
        /// <param name="symbolSet">A set to remove the <see cref="CodeOptimization" /> symbols from.</param>
        private static void RemoveCompilationCodeOptimizationSymbols([NotNull] ISet<string> symbolSet)
        {
            symbolSet.Remove(Symbol.CodeOptimizationDebug);
            symbolSet.Remove(Symbol.CodeOptimizationRelease);
        }

        /// <summary>Gets the current symbols for a <see cref="BuildTargetGroup" />.</summary>
        /// <param name="buildTargetGroup">Which <see cref="BuildTargetGroup" /> to get the symbols for.</param>
        /// <param name="symbols">A set to populate with the build target symbols.</param>
        private static void GetBuildTargetGroupSymbols(BuildTargetGroup buildTargetGroup, [NotNull] ISet<string> symbols)
        {
            PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup, out string[] currentSymbols);
            symbols.UnionWith(currentSymbols);
        }
    }
}