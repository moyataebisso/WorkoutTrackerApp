namespace WorkoutTrackerApp
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void OnThemeToggled(object sender, ToggledEventArgs e)
        {
            // Toggle between light and dark theme
            Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
        }
    }
}
