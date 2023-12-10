public class OKButton : Button
{
    private void Start()
    {
        Initialize();
    }

    protected override void Execute()
    {
        if (transform.parent.GetComponent<HowToPlayMessage>() != null)
        {
            transform.parent.GetComponent<HowToPlayMessage>().Close();
        }
        else if (transform.parent.GetComponent<CongratulationMessage>() != null)
        {
            transform.parent.GetComponent<CongratulationMessage>().Close();
        }
        else
        {
            transform.parent.GetComponent<Message>().Close();
        }
    }
}
