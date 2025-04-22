using UnityEngine;

public interface IFollower
{
    public Transform target { get; set; }

    public void Follow();
}
