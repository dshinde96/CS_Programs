namespace CustomExceptions;

class OddNumberException:Exception{

    public override string Message{
        get{
            return "Divisor cannot be odd";
        }
    }

    public override string? HelpLink { get => "This is the link for more refereence.";}
}