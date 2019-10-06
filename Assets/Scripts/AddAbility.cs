public class AddAbility {
    private static string[] abilityNames = { "StopNPCAbility" };

    public static string randomiseAbility() {
        int rand = (int)UnityEngine.Random.Range(0, abilityNames.Length - 0.000001f);

        return abilityNames[rand];
    }
}