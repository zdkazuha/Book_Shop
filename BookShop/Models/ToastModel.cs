namespace BookShop.Models
{
    public enum ToastType
    {
        danger,
        info,
        success,
        warning
    }

    public class ToastModel(string message = "Action completed sucsecfuly",
                            ToastType type = ToastType.success)
    {
        public string Message { get; set; } = message;
        public ToastType Type { get; set; } = type;

    }
}