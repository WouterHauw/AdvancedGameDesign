using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerStatsTest
{
    [Test]
    public void PlayerBeginsWithNoSticks()
    {
        //Arrange
        const int initialSticks = 0;
        //Act
        PlayerController player = new PlayerController();
        //Assert
        Assert.That(player.numSticks, Is.EqualTo(initialSticks));
    }

    [TestCase(5,5)]
    [TestCase(-1,0)]
    public void PlayerSticksCanBeUpdated(int x, int expectedNumSticks)
    {
        //Arrange
        PlayerController player = new PlayerController();
        //Act
        player.UpdateStick(x);
        //Assert
        Assert.That(player.numSticks, Is.EqualTo(expectedNumSticks));
    }


}
