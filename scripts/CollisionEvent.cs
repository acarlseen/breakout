using System;


// TODO - use this as a module for composition.
// IDEALLY this is used as a static event handler
public class CollisionEvent
{
    public Action Collision;

    public void CollisionEventHandler(object obj)
    {
        Collision?.Invoke();
    }
}