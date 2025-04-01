namespace WorkoutTrackerApp
{
    public partial class WorkoutInputPage : ContentPage
    {
        private List<string> currentWorkouts = new();

        public WorkoutInputPage()
        {
            InitializeComponent();
            WorkoutTypePicker.SelectedIndexChanged += OnWorkoutTypeChanged;
        }

        private void OnWorkoutTypeChanged(object sender, EventArgs e)
        {
            string selected = WorkoutTypePicker.SelectedItem?.ToString() ?? "";
            currentWorkouts.Clear();

            switch (selected)
            {
                case "Chest + Arms":
                    currentWorkouts.AddRange(new[]
                    {
                        "Tricep Press",
                        "Pullups + Dips",
                        "Flat Dumbbell Press",
                        "Overhead Press + Lateral Flys",
                        "Pectoral Fly",
                        "EZ Bar Curls",
                        "Abs"
                    });
                    break;

                case "Back + Biceps": // we'll treat this as Back + Shoulders
                    currentWorkouts.AddRange(new[]
                    {
                        "Lat Pulldown",
                        "Pullups + Dips",
                        "Seated Rows",
                        "Overhead Press + Lateral Raise",
                        "Abs"
                    });
                    break;

                case "Legs":
                    currentWorkouts.AddRange(new[]
                    {
                        "Standing Quad Stretch",
                        "Front Leg Elevated Hamstring Stretch",
                        "Straight Leg Raise",
                        "Squat",
                        "Reverse Step Ups",
                        "Abs"
                    });
                    break;
            }

            WorkoutListView.ItemsSource = null;
            WorkoutListView.ItemsSource = currentWorkouts;
        }

        private void OnAddWorkoutClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewWorkoutEntry.Text))
            {
                currentWorkouts.Add(NewWorkoutEntry.Text.Trim());
                NewWorkoutEntry.Text = "";
                WorkoutListView.ItemsSource = null;
                WorkoutListView.ItemsSource = currentWorkouts;
            }
        }

        private void OnRemoveWorkoutClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var workout = (string)button.BindingContext;

            if (currentWorkouts.Contains(workout))
            {
                currentWorkouts.Remove(workout);
                WorkoutListView.ItemsSource = null;
                WorkoutListView.ItemsSource = currentWorkouts;
            }
        }
    }
}
