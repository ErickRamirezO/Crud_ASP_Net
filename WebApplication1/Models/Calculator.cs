namespace WebApplication1.Models;

public class Calculator
{
    public int firstNumber { get; set; }
    public int secondNumber { get; set; }

    public int Add()
	{
        return firstNumber + secondNumber;
	}
}
