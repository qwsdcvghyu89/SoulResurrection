using Mutagen.Bethesda;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace SoulResurrection {
    public class Program {
        public static async Task<int> Main(string[] args) {
            if (!OperatingSystem.IsWindowsVersionAtLeast(7))
                return -10;
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .AddRunnabilityCheck(IsMainModPresent)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SoulResurrectionPatch.esp")
                .Run(args);
        }

        private static void IsMainModPresent(IRunnabilityState state) {
            if (!state.LoadOrder.Any((x) => x.Value.FileName == "SoulResurrection.esp"))
                throw new Exception("Missing master!");
        }

        private static async Task RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state) {
            // Get NPCs
            // Filter
            // Add MarrowItemCopy
        }
    }
}
