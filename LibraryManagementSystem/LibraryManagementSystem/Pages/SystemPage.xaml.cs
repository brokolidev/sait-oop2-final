using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class SystemPage : ContentPage
{
    public SystemPage()
    {
        InitializeComponent();

        // Update the text of the CurrentStudentDays label
        CurrentStudentDays.Text = DisplayStudentRentalDays().ToString();

        // Update the text of the CurrentInstructorDays label
        CurrentInstructorDays.Text = DisplayInstructorRentalDays().ToString();
    }

    private int DisplayStudentRentalDays()
    {
        int studentDays = SystemEnv.RentalDaysForStudent != 0 ? SystemEnv.RentalDaysForStudent : 14;
        return studentDays;

    }

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

}