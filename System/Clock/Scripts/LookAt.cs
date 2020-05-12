using UnityEngine;

/// <summary>
/// Simple look-at script.
/// </summary>
public class LookAt : MonoBehaviour
{
    #region Public_Members

    /// <summary>
    /// The target at wich the object will look.
    /// </summary>
    public Transform Target;

    #endregion

    void Update()
    {
        var lookAt = Quaternion.LookRotation(Target.position - transform.position).eulerAngles;
        transform.rotation = Quaternion.Euler(-90, 0, lookAt.y - 90);
    }
}
