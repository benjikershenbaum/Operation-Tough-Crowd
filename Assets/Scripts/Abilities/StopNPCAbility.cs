public class StopNPCAbility : PlayerAbility {
    public override void onCallAbility() {
        base.onCallAbility();

        AIManager.stopAllAI();
    }
}