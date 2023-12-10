public abstract class Button : Clickable
{
    protected override void Update()
    {
        base.Update();

        if (IsActivatedOnce == true)
        {
            Execute();
        }
    }

    protected abstract void Execute();
}
