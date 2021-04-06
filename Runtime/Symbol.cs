using JetBrains.Annotations;

namespace AlkimeeGames.CodeOptimizationSymbols
{
    /// <summary>The symbols set based on the 'CompilationPipeline.codeOptimization' mode.</summary>
    [PublicAPI]
    public static class Symbol
    {
        /// <summary>'CodeOptimization.Debug' Symbol.</summary>
        [PublicAPI] public const string CodeOptimizationDebug = "UNITY_EDITOR_DEBUG";

        /// <summary>'CodeOptimization.Release' Symbol.</summary>
        [PublicAPI] public const string CodeOptimizationRelease = "UNITY_EDITOR_RELEASE";
    }
}