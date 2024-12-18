using QzemApp.ViewModels;

namespace QzemApp.Views;

public partial class DimonaDetailPage : ContentPage
{
    public DimonaDetailPage(DimonaDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}