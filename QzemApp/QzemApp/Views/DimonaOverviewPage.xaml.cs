using QzemApp.ViewModels;

namespace QzemApp.Views
{
    public partial class DimonaOverviewPage : ContentPage
    {
        public DimonaOverviewPage(DimonaOverviewViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}