namespace BookShop.Models
{
    public enum DialogType
    {
        danger,
        info,
        success,
        warning
    }

    public class ConfirmDialogViewModel
    {
        public string DialogId { get; set; }
        public string? Title { get; set; }
        //public string BookTitle { get; set; }
        public string? Message { get; set; }
        public DialogType Mode { get; set; } = DialogType.info;
    }
}