namespace residential_complex.Io.Interfaces;

public interface IUi
{
    public void ShowMessage(string message);
    public int GetIntegerFromUser(string message);
    public decimal GetDecimalFromUser(string message);
    public string GetStringFromUser(string message);
    public DateTime GetDateTimeFromUser(string message);

    public Double GetDoubleFromUser(string message);
}