using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class SystemPage : ContentPage
{
    public SystemPage()
    {
        InitializeComponent();

        // Updates the text of the CurrentStudentDays label
        CurrentStudentDays.Text = DisplayStudentRentalDays().ToString();

        // Updates the text of the CurrentInstructorDays label
        CurrentInstructorDays.Text = DisplayInstructorRentalDays().ToString();
    }


    /// <summary>
    /// Displays the rental days for students.
    /// </summary>
    /// <returns>The number of rental days for students.</returns>
    private int DisplayStudentRentalDays()
    {
        int studentDays = SystemEnv.RentalDaysForStudent != 0 ? SystemEnv.RentalDaysForStudent : 14;
        return studentDays;

    }


    /// <summary>
    /// Displays the rental days for instructors.
    /// </summary>
    /// <returns>The number of rental days for instructors.</returns>
    private int DisplayInstructorRentalDays()
    {
        int instructorDays = SystemEnv.RentalDaysForInstructor != 0 ? SystemEnv.RentalDaysForInstructor : 30;
        return instructorDays;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set buttons by user types
        RentalButton.IsVisible =
            SystemEnv.LoggedInUser is Student ||
            SystemEnv.LoggedInUser is Instructor;

        CustomerButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        InventoryButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        SystemButton.IsVisible =
            SystemEnv.LoggedInUser is Administrator;
    }

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    private void CustomerButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }



    /// <summary>
    /// Event handler for the Apply Changes button click event.
    /// Updates the rental days for students and instructors based on user input.
    /// Displays success or error messages depending on whether user inputs an integer or not.
    /// </summary>
    private void ApplyChangesButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(StudentDaysEntry.Text))
        {
            if (int.TryParse(StudentDaysEntry.Text, out int studentDays))
            {
                // Updates rental days for students and resets the entry field
                SystemEnv.RentalDaysForStudent = studentDays;
                StudentDaysEntry.Text = "";

                // Updates the displayed rental days for students
                CurrentStudentDays.Text = DisplayStudentRentalDays().ToString();
                DisplayAlert("Success", "Rental days updated successfully.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Invalid input for student rental days. Please enter a valid number.", "OK");
                return;
            }
        }

        if (!string.IsNullOrWhiteSpace(InstructorDaysEntry.Text))
        {
            if (int.TryParse(InstructorDaysEntry.Text, out int instructorDays))
            {
                // Updates rental days for instructors and resets the entry field
                SystemEnv.RentalDaysForInstructor = instructorDays;
                InstructorDaysEntry.Text = "";

                // Updates the displayed rental days for instructors
                CurrentInstructorDays.Text = DisplayInstructorRentalDays().ToString();
                DisplayAlert("Success", "Rental days updated successfully.", "OK");

            }
            else
            {
                DisplayAlert("Error", "Invalid input for instructor rental days. Please enter a valid number.", "OK");
                return;
            }
        }

   
        
    }

}