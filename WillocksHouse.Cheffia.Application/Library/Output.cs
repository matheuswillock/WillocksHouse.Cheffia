namespace WillocksHouse.Cheffia.Application.Library;

public class Output : IOutput
{
    public Output()
    {
        IsValid = true;
        Messages = new List<string>();
        ErrorMessages = new List<string>();
        Result = null;
    }

    public bool IsValid { get; set; }
    public List<string> Messages { get; set; }
    public List<string> ErrorMessages { get; set; }
    public object? Result { get; set; }

    public void AddResult(object result)
    {
        Result = result;
    }

    public object GetResult()
    {
        if (Result != null)
            return Result;

        throw new Exception("Result is null");
    }

    public void AddErrorMessage(string error)
    {
        ErrorMessages.Add(error);
        IsValid = false;
    }

    public void AddMessage(string error)
    {
        Messages.Add(error);
    }
}