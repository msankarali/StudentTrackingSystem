namespace Msa.StudentTrackingSystem.UI.Win.Interfaces
{
    public interface IStatusBarShortcut : IStatusBarDescription
    {
        string StatusBarShortcut { get; set; }
        string StatusBarShortcutDescription { get; set; }
    }
}
