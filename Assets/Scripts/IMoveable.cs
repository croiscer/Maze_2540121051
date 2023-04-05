using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public void ShiftMoveTarget(Vector3 direction);
    public void MovePosition();
}
