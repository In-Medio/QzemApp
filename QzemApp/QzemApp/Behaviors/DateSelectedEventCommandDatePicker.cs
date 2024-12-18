using System.Windows.Input;

namespace QzemApp.Behaviors;

public sealed class DateSelectedCommandDatePicker
{
    public static readonly BindableProperty DateSelectedCommandProperty =
    BindableProperty.CreateAttached(
        "DateSelectedCommand",
        typeof(ICommand),
        typeof(DateSelectedCommandDatePicker),
        default(ICommand),
        BindingMode.OneWay,
        null,
        PropertyChanged);

    private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DatePicker datePicker)
        {
            datePicker.DateSelected -= DatePickerSelectedDate;
            datePicker.DateSelected += DatePickerSelectedDate;
        }
    }

    private static void DatePickerSelectedDate(object sender, DateChangedEventArgs e)
    {
        var datePicker = sender as DatePicker;

        if (datePicker != null && datePicker.IsEnabled)
        {
            datePicker.Date = DateTime.Now.Date;
            var command = GetSelectedDateCommand(datePicker);
            if (command != null && command.CanExecute(e))
            {
                command.Execute(e);
            }
        }
    }

    public static ICommand GetSelectedDateCommand(BindableObject bindableObject)
    {
        return (ICommand)bindableObject.GetValue(DateSelectedCommandProperty);
    }

    public static void SetItemTappedCommand(BindableObject bindableObject, object value)
    {
        bindableObject.SetValue(DateSelectedCommandProperty, value);
    }
}

