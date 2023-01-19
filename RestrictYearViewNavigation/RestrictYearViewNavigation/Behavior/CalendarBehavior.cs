using Syncfusion.Maui.Calendar;

namespace RestrictYearViewNavigation
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar calendar;
        private Button allowNavigationButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.FindByName<SfCalendar>("calendar");
            this.calendar.AllowViewNavigation = true;
            this.allowNavigationButton = bindable.FindByName<Button>("allowNavigationButton");
            this.allowNavigationButton.Text = this.calendar.AllowViewNavigation ? "Disable view navigation" : "Enable view navigation";
            this.allowNavigationButton.Clicked += AllowNavigationButton_Clicked;
        }

        private void AllowNavigationButton_Clicked(object sender, EventArgs e)
        {
            if (this.calendar.AllowViewNavigation)
            {
                this.calendar.AllowViewNavigation = false;
                this.allowNavigationButton.Text = "Enable view navigation";
            }
            else
            {
                this.calendar.AllowViewNavigation = true;
                this.allowNavigationButton.Text = "Disable view navigation";
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.allowNavigationButton != null)
            {
                this.allowNavigationButton.Clicked -= AllowNavigationButton_Clicked;
            }

            this.allowNavigationButton = null;
            this.calendar = null;
        }
    }
}
