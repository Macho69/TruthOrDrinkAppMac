using System.Collections.ObjectModel;

namespace TruthOrDrinkAppMac;

public partial class FriendsListPage : ContentPage
{
    private readonly UsersRepository _databaseService;

    public ObservableCollection<TruthOrDrinkAppMac.MVVM.Model.User> Users { get; set; }

    public FriendsListPage()
    {
        InitializeComponent();

        _databaseService = new UsersRepository();
        Users = new ObservableCollection<TruthOrDrinkAppMac.MVVM.Model.User>(_databaseService.GetAllUsers());

        BindingContext = this;
    }
}
