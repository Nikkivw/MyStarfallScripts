public virtual Vector3 SteerToTarget(Vector3 currentWaypoint)
{
    var position = transform.position;
    Vector3 direction = currentWaypoint - position;
    var distance = direction.magnitude;
    cw = currentWaypoint;
    Debug.DrawLine(position, currentWaypoint);
    direction.Normalize();

    Vector3 force = direction * Speed * Time.fixedDeltaTime;

    var steeringForce = force - movementForce.Direction;
    var newVelocity = movementForce.Direction + steeringForce / (1 + forceBody.Mass * SteerAdjustment);//forceBody.Mass;//Mathf.Max(forceBody.Mass - SteerAdjustment, 1f);
    if (!newVelocity.IsSameDirectionAs(movementForce.Direction, SteerTreshold))
    {
        newVelocity = newVelocity.normalized * MathExtensions.Clamp(movementForce.Direction.magnitude, 1E-05f, distance);
    }
    newVelocity /= Time.fixedDeltaTime;
    return newVelocity;
}