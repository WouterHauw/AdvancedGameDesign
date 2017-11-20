

public interface AbilityInterface  {

    //Activate the actual ability and all the changes that need to be made
    void ActivateAbility();

    //Most abilities will have a passive/off mode use this
    void DeactivateAbility();

    //Give values to the variable, keeps start clean
    void InitializeVariables();
}
