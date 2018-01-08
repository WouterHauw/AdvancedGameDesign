using UnityEngine;

public interface IAbilityInterface
{
    //Activate the actual ability and all the changes that need to be made
    void ActivateAbility(GameObject aObject, Animator playerAnimation);

    //Most abilities will have a passive/off mode use this
    void DeactivateAbility(GameObject aObject, Animator playerAnimation);

    //Give values to the variable, keeps start clean
    void InitializeVariables();
}