using System;

static class QuestLogic {
    public static bool CanFastAttack(bool knightIsAwake) {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake) {
        return knightIsAwake || archerIsAwake || prisonerIsAwake;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake) {
        return !archerIsAwake && prisonerIsAwake;
    }

    public static bool CanFreePrisoner(
        bool knightIsAwake, 
        bool archerIsAwake, 
        bool prisonerIsAwake,
        bool petDogIsPresent) {

        if (archerIsAwake && knightIsAwake && prisonerIsAwake) {
            return false;
        }

        if (!petDogIsPresent && !prisonerIsAwake && !knightIsAwake && !archerIsAwake) {
            return false;
        }

        if (archerIsAwake && !petDogIsPresent) {
            return false;
        }

        if (knightIsAwake && !petDogIsPresent) {
            return false;
        }

        if (!petDogIsPresent && prisonerIsAwake && !knightIsAwake || !archerIsAwake) {
            return true;
        }

        return archerIsAwake && knightIsAwake && prisonerIsAwake && petDogIsPresent;
    }
}
