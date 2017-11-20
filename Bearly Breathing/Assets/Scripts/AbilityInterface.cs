using UnityEngine;

public interface AbilityInterface 
{

    //Activate the actual ability and all the changes that need to be made
    void ActivateAbility(GameObject aObject);

    //Most abilities will have a passive/off mode use this
    void DeactivateAbility(GameObject aObject);

    //Give values to the variable, keeps start clean
    void InitializeVariables();
}
