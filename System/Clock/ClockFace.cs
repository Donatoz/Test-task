using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Represents a clock face with 3 clock hands (seconds, minutes and hours).
/// </summary>
public class ClockFace : MonoBehaviour
{
    #region Public_Members

    /// <summary>
    /// Time multiplier (only shifts positions of clock hands).
    /// </summary>
    public float TimeMultiplier = 1;

    #endregion

    #region Private_Members

    /// <summary>
    /// Seconds hand of the clock.
    /// </summary>
    [SerializeField]
    private ClockHand secondsHand;
    /// <summary>
    /// Minutes hand of the clock.
    /// </summary>
    [SerializeField]
    private ClockHand minutesHand;
    /// <summary>
    /// Hours hand of the clock.
    /// </summary>
    [SerializeField]
    private ClockHand hoursHand;

    #endregion

    private void Awake()
    {
        // In 1 hour we have 60 minutes and in 1 minute we have 60 seconds.
        // Therefore, we just divide current seconds by 60 and then multiply it by 360,
        // because in 1 full seconds hand turnover there is only 60 seconds and 360 degrees on the clock face at the same time.
        // All hands need to be rotated "clockwise", so we multiply all values by -1.

        secondsHand.SetRotationCalculator(() =>
        {
            return Quaternion.Euler(secondsHand.transform.rotation.x, secondsHand.transform.rotation.y, 
                DateTime.Now.Second / 60f * -360f * TimeMultiplier);
        });

        // Same logic is in the minutes hand rotation.

        minutesHand.SetRotationCalculator(() =>
        {
            return Quaternion.Euler(minutesHand.transform.rotation.x, minutesHand.transform.rotation.y, 
                (float)DateTime.Now.Minute / 60f * -360f * TimeMultiplier);
        });

        // In one hour full turnover there are 12 hours,
        // so we need to divide current hours by 12, not by 60.

        hoursHand.SetRotationCalculator(() =>
        {
            return Quaternion.Euler(hoursHand.transform.rotation.x, hoursHand.transform.rotation.y, 
                (float)DateTime.Now.Hour / 12f * -360f * TimeMultiplier);
        });
    }

    private void Update()
    {
        secondsHand.UpdateRotation();
        minutesHand.UpdateRotation();
        hoursHand.UpdateRotation();
    }
}
