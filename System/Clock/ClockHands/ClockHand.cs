using System;
using UnityEngine;

/// <summary>
/// Represents a clock hand with specific rotation logic.
/// </summary>
public class ClockHand : MonoBehaviour
{
    #region Public_Members

    /// <summary>
    /// Linear interpolation speed of the hand rotation.
    /// </summary>
    [Range(1, 20)]
    public float LerpSpeed = 10;

    #endregion

    #region Private_Members

    /// <summary>
    /// Delegate for calculating rotation of this hand. (<see cref="Quaternion.identity"/> by default)
    /// </summary>
    private Func<Quaternion> rotationCalculator = delegate { return Quaternion.identity; };

    #endregion

    /// <summary>
    /// Update hand rotation according to the rotation logic.
    /// </summary>
    public void UpdateRotation()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotationCalculator(), Time.deltaTime * LerpSpeed);
    }

    /// <summary>
    /// Set new rotation logic calculator.
    /// </summary>
    /// <param name="calculator"></param>
    public void SetRotationCalculator(Func<Quaternion> calculator)
    {
        rotationCalculator = calculator;
    }
}
